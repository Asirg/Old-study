using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.Threading;

namespace Server
{

    struct Messege_client
    {
        public string id;
        public Messege_client(string surname) { id = surname; }
    }
    struct Massege
    {
        public string massage;
        public Massege(string value_massage) { massage = value_massage; }
    }

    // Класс для збереження даних, потрібних для роботи з підключення
    class Serv
    {
        public static int port = 8005;
        public static string address = "127.0.0.1";

        static public IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(Serv.address), Serv.port);
    };
    class Server
    {
        static string list_client = "";                     // Список підключених
        static List<Socket> sockets = new List<Socket> { }; // Для зберігання сокетів
        static object locker = new object();

        //Функція для роботи з підключеними сокетами
        static public void Client_accept(object arg)
        {
            Socket socket = (Socket)arg;                // Отриманий сокет
            StringBuilder builder = new StringBuilder();
            int buffer_bytes = 0;
            byte[] buffer = new byte[256];
            do
            {
                buffer_bytes = socket.Receive(buffer);
                builder.Append(Encoding.Unicode.GetString(buffer, 0, buffer_bytes));
            }
            while (socket.Available > 0);

            Messege_client mess = JsonConvert.DeserializeObject<Messege_client>(builder.ToString()); // ДиСеріалізація структури у формат json

            lock (locker)
            {
                list_client = list_client + DateTime.Now + " : " + builder.ToString() + "\n";                                   // Занесемо підключенного кліента до списку
            }
            //Відправляемо відповідь
            Massege answ = new Massege(builder.ToString() + " Подключен");
            buffer = Encoding.Unicode.GetBytes(JsonConvert.SerializeObject(answ));
            socket.Send(buffer);

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Ждем подключения. . .");

            // Створимо сокет
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listenSocket.Bind(Serv.ipPoint); // Підклемо до адресси
            listenSocket.Listen(10);         // Почнемо прослуховування

            bool timer_flag = true;
            while (true)
            {
                if (timer_flag) // Таймер
                {
                    List<Socket> cond = new List<Socket>() { listenSocket };
                    Socket.Select(cond, null, null, 100000);                // Перевірка на зміни у сокетах
                    if (cond.Count > 0)
                    {
                        // Запускаемо Task - таймер
                        Task timer = Task.Run(() =>
                        {
                            list_client += "Время начала таймера :  " + DateTime.Now + "\n";
                            Thread.Sleep(TimeSpan.FromSeconds(22));

                            byte[] buffer = new byte[512];
                            Massege answ = new Massege(list_client);
                            buffer = Encoding.Unicode.GetBytes(JsonConvert.SerializeObject(answ));
                            for (int i = 0; i < sockets.Count; i++)
                                sockets[i].Send(buffer);
                        });
                        timer_flag = false;
                    }
                }
                // Приймаємо запит
                sockets.Add(listenSocket.Accept());
                Thread th = new Thread(new ParameterizedThreadStart(Client_accept)); //Новий потік для роботи зі сокетом
                th.Start(sockets[sockets.Count - 1]);
            }
        }
    }
}

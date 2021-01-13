using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.Threading;

namespace Client
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
    // Класс для збереження даних, потрібних для роботи з підключенням
    class Serv  
    {
        static public int port = 8005;           
        static public string address = "127.0.0.1";

        //Объект який зв'язує порт та адрессу для підключення сокету
        static public IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(Serv.address), Serv.port);
    };

    class Client
    {
        //Функція для підключення сокету до сервера
        static public void client_connect(object number)
        {
            //Створимо повідомлення кліента
            Messege_client client = new Messege_client("Muminov_" + number.ToString()); // Створимо структуру с даними клиента
            string client_Json = JsonConvert.SerializeObject(client);                   // Серіалізація структури у формат json

            // Створимо tcp сокет
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Начало подключения клиента : " + client_Json);

            socket.Connect(Serv.ipPoint);                           // Підключемо сокет до сервера
            byte[] buffer = Encoding.Unicode.GetBytes(client_Json); // Перетворимо повідомлення в набір байтів
            socket.Send(buffer);                                    // Відправемо повідомлення через зв'язок сокетів

            while (true)    //Очікування на відповідь
            {
                buffer = new byte[512];
                StringBuilder builder = new StringBuilder();
                int buffer_bytes = 0; 
                do
                {
                    buffer_bytes = socket.Receive(buffer, buffer.Length, 0);
                    builder.Append(Encoding.Unicode.GetString(buffer, 0, buffer_bytes));
                }
                while (socket.Available > 0);
                Massege answ = JsonConvert.DeserializeObject<Massege>(builder.ToString());
                Console.WriteLine("ответ сервера: " + answ.massage); //Відповідь від сервера

            }
        }

        static void Main(string[] args)
        {
            for (int i = 0; i <12; i++)
            {
                //Послідовно створюємо потік для кожного кліента
                Thread th = new Thread(new ParameterizedThreadStart(client_connect));
                th.Start(i);
            }

        }
    }
}
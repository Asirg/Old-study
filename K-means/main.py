import PySimpleGUI as sg
from Read_File import read
import data_processing
from k_means import k_means
import distans as d
import pandas as pd
from datetime import datetime
import show

pd.options.display.max_rows = 1000
layout = [
    [sg.Text('Файл з даними:')],
    [sg.FileBrowse('обрати файл'), sg.Text(size=(70, 1))],
    [sg.Text('Кількість кластерів'), sg.InputText('2', size=(2, 1))],
    [sg.Text('Метрика'), sg.InputCombo(('Евклідова відстань', 'Квадрат відстані Евкліда',
                                        'Мангеттенська відстань', 'Відстань Чебишова'),
                                       default_value="Евклідова відстань")],
    [sg.Checkbox('2Д'), sg.Checkbox('3Д'), sg.Checkbox('Зберегти у Excel')],
    [sg.Text("Наявні стовпчики (для відображення завантажте файл):")],
    [sg.Input(size=(90, 1), key='Columns',disabled=True, focus=True)],
    [sg.Text("Стовпчики для кластеризації, пропустіть якщо за всіма стовпчиками:")],
    [sg.InputText('pk,age,carrier', size=(90, 1))],
    [sg.Text('Результат кластеризації:')],
    [sg.Output(size=(90, 20))],
    [sg.Submit('Завантажити'), sg.Submit('Кластеризація', disabled=True), sg.Cancel('Вийти')]
]
window = sg.Window('Кластеризация K-MEANS', layout)
while True:
    event, values = window.read()

    if event in ['Вийти', None]:
        break
    elif event in 'Завантажити':
        if values['обрати файл'] == "":
            print("Оберіть потрібний файл!!!")
        else:
            try:
                data = read(values['обрати файл'])
                window['Columns'].update(str(list(data.columns)).replace("'","")[1:-1])
                window['Кластеризація'].update(disabled=False)
                print("Файл успішно завантажен!")
            except:
                print("Некоректний файл")

    elif event in 'Кластеризація':
        process_data = data
        if int(values[0]) < 2:
            print("Кількість кластерів повинна бути більше 1 !!!")
        else:
            print("-" * 120)
            count_clusters = int(values[0])
            metrics = {'Евклідова відстань': d.Euclid, 'Квадрат відстані Евкліда': d.Euclid2,
                       'Мангеттенська відстань': d.Manhattan, 'Відстань Чебишова': d.Сhebyshev}
            if values[5] == "":
                columns = list(process_data.columns)
            else:
                columns = values[5].split(",")
            try:
                for i in columns:
                    process_data[i].dtype == "bool"
                print("Обрані стовпчики:\n" + str(columns))
                print("Кількість кластерів: " + str(count_clusters))
                for i in columns:
                    if process_data[i].dtype == "bool" or process_data[i].dtype == "object":
                        process_data[i] = data_processing.Fill_0(process_data[i])
                        process_data[i] = data_processing.Coding_Text(process_data[i])
                    else:
                        process_data[i] = data_processing.Fill_mean(process_data[i])
                        process_data[i] = data_processing.Normalization_minmax(process_data[i])
                print("Виконана підготовка даних до кластеризації!")
                process_data['old_index'] = [i for i in range(len(process_data))]

                process_data = k_means(process_data, columns, count_clusters,
                                                       metrics[values[1]])
                print("Результат кластеризації")
                if values[2] and len(columns) > 1:
                    show.show2D(process_data)

                if values[3] and len(columns) > 2:
                    show.show3D(process_data)

                for i in range(count_clusters):
                    print("Кластер номер " + str(i) + " :" + str(len(process_data[i])))
                    process_data[i] = pd.DataFrame(process_data[i])
                    print(process_data[i])
                #
                if values[4]:
                    with pd.ExcelWriter(
                            'output' + str(datetime.now()).split('.')[0].replace(':', '-') + '.xlsx') as writer:
                        for i in range(count_clusters):
                            process_data[i].to_excel(writer, sheet_name='cluster - ' + str(i))
            except:
                print("Неккоректно визначені стовпчики")

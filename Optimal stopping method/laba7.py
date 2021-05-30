from Educ.TRP.CalculationOfProbability import Calculation
from Educ.TRP.Сharts import startCharts
import PySimpleGUI as gui
import datetime
import time

import colorama as col

col.init()

gui.SetOptions(background_color='#424242',
               text_element_background_color='#424242',
               element_background_color='#000000',
               input_elements_background_color='#F7F3EC',
               progress_meter_color=('green', 'blue'),
               button_color=('white', '#455A64'),
               font=("Cambria", 13), )

HeaderFont = ("Cambria", 20)

layout = [
    [gui.Text('Вхідні дані:', font=HeaderFont, text_color='#F4511E')],
    [gui.Text('Кількість експеререментів, M = ', size=(30, 1)), gui.InputText('100', size=(5, 1))],
    [gui.Text('Кількість випадкових величин, N = ', size=(30, 1)), gui.InputText('100', size=(5, 1))],
    [gui.Text('Розмір поступки, d = ', size=(30, 1)), gui.InputText('0', size=(3, 1))],
    [gui.Text('Границі значень випадкових чисел:', size=(30, 1)), gui.InputText('160', size=(3, 1)),
     gui.Text('< X <'), gui.InputText('190', size=(3, 1))],
    [gui.Text('_' * 100, size=(45, 1))],
    [gui.Text('Результати серії експерементів:', font=HeaderFont)],
    [gui.Output(size=(45, 15))],
    [gui.Button('Розрахувати'), gui.Button('Визначити залежності')]
]
window = gui.Window('Рішення за правилом оптимальної зупинки', layout)
while True:
    event, values = window.read()
    if event in ['Вийти', None]:
        break
    elif event in 'Розрахувати':
        try:
            if int(values[0]) < 0 or int(values[1]) < 0:
                raise Exception("M та N повині бути більше нуля")
            start = time.time()
            print("Час початку розрахунку: " + datetime.datetime.now().strftime("%H:%M:%S"))

            p = Calculation(int(values[0]), int(values[1]), int(values[2]), float(values[3]), float(values[4]))

            print("Час розрахунку: {:.6f}".format(time.time() - start))
            print("M: {0}, N: {1}, d: {2}".format(values[0], values[1], values[2]))
            print("границі: {0} < X < {1}".format(values[3], values[4]))
            print("\nрозрахована ймовірність = {:.2%}".format(p))
            print("*" * 57)

        except Exception as e:
            gui.popup_error("Error", e)

    elif event in 'Визначити залежності':
        startCharts()

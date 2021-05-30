from Educ.TRP.CalculationOfProbability import Calculation
import matplotlib.pyplot as plt
import PySimpleGUI as gui
import numpy as np
import datetime
import time


def startCharts():
    gui.SetOptions(background_color='#424242',
                   text_element_background_color='#424242',
                   element_background_color='#000000',
                   input_elements_background_color='#F7F3EC',
                   progress_meter_color=('green', 'blue'),
                   button_color=('white', '#455A64'),
                   font=("Cambria", 13), )

    HeaderFont = ("Cambria", 20)

    layout = [
        [gui.Text('Вхідні дані:', justification='center', font=HeaderFont, size=(20, 1), text_color='#F4511E')],
        [gui.Text('M = ', size=(3, 1)), gui.InputText('1000', size=(5, 1)),
         gui.Text('', size=(2, 1)),
         gui.Text('крок M = ', size=(7, 1)), gui.InputText('200', size=(5, 1))],

        [gui.Text('N = ', size=(3, 1)), gui.InputText('100', size=(5, 1)),
         gui.Text('', size=(2, 1)),
         gui.Text('крок N = ', size=(7, 1)), gui.InputText('10', size=(5, 1))],

        [gui.Text('t = ', size=(3, 1)), gui.InputText('100', size=(5, 1)),
         gui.Text('', size=(2, 1)),
         gui.Text('крок t = ', size=(7, 1)), gui.InputText('5', size=(5, 1))],
        [gui.Text('d = ', size=(3, 1)), gui.InputText('0,0.02,0.04,0.06,0.08,0.1', size=(20, 1))],
        [gui.InputText('0', size=(3, 1)), gui.Text('<  X <'), gui.InputText('100', size=(3, 1))],

        [gui.Text('Розрахунки:', justification='center', font=HeaderFont, size=(20, 1))],
        [gui.Output(size=(33, 10))],
        [gui.Button('Залежність P від M'), gui.Button('Залежність P від N')],
        [gui.Button('Завдання МКР')]
    ]
    window = gui.Window('Залежності', layout)
    while True:
        event, values = window.read()

        M = [int(i) for i in str(values[0]).split(",")]
        stepM = int(values[1])
        N = [int(i) for i in str(values[2]).split(",")]
        stepN = int(values[3])
        t = int(values[4])
        stept = int(values[5])
        d = [float(i) for i in str(values[6]).split(",")]
        minValue = float(values[7])
        maxValue = float(values[8])

        if event in ['Вийти', None]:
            break
        elif event in 'Залежність p від M':
            print("Час початку розрахунку: " + datetime.datetime.now().strftime("%H:%M:%S"))
            start = time.time()

            const = N[0]
            if len(M) == 1:
                step = np.arange(0, M[0] + 1, stepM)
            else:
                step = M
            p = []
            for i in range(len(d)):
                p.append([])
                for s in step:
                    p[i].append(Calculation(s, const, d[i], minValue, maxValue))
                    print("M:{0}, N:{1}, d:{2}, {3}<X<{4}".format(s, const, d[i], minValue, maxValue))
                    print("p = {0:.4f}".format(p[i][len(p[i]) - 1]))
                    print("*" * 40)
            print("Час розрахунку: {:.6f}".format(time.time() - start))
            print("*" * 82)
            plot(p, step, "M", d, "N", const)
        elif event in 'Залежність p від N':
            print("Час початку розрахунку: " + datetime.datetime.now().strftime("%H:%M:%S"))
            start = time.time()

            const = M[0]
            if len(N) == 1:
                step = np.arange(0, N[0] + 1, stepM)
            else:
                step = N
            p = []
            for i in range(len(d)):
                p.append([])
                for s in step:
                    p[i].append(Calculation(s, const, d[i], minValue, maxValue))
                    print("M:{0}, N:{1}, d:{2}, {3}<X<{4}".format(const, s, d[i], minValue, maxValue))
                    print("p = {0:.4f}".format(p[i][len(p[i]) - 1]))
                    print("*" * 40)
            print("Час розрахунку: {:.6f}".format(time.time() - start))
            print("*" * 82)
            plot(p, step, "N", d, "M", const)

        elif event in 'Завдання МКР':
            print("Час початку розрахунку: " + datetime.datetime.now().strftime("%H:%M:%S"))
            start = time.time()

            p = []
            tx = np.arange(1, t + 1, stept)
            print(d)
            for i in d:
                p.append([])
                for j in tx:
                    p[len(p) - 1].append(Calculation(M[0], N[0], i, minValue, maxValue, j))

            for i in range(len(p)):
                SimplePlot(p[i], tx, "Залежність P(t) від t, при d = " + str(d[i] * 100) + "%", "t", "P(t)")
            maxP = [max(i) for i in p]
            maxt = [p[i].index(maxP[i]) * stept for i in range(len(p))]
            SimplePlot(maxP, d, "Залежність P(t)max від d", "d", "P(t)max")
            SimplePlot(maxt, d, "Залежність оптимального t від d", "d", "t", [0, 100])
            print("Середні ймовірності при різних d")
            print([np.mean(np.array(i)) for i in p])

            plt.show()


def plot(x, y, axN, d, const, constValue):
    fig = plt.figure()
    ax = fig.add_subplot(111)

    for i in range(len(d)):
        ax.plot(y, x[i], label="p({0}), {1}:{2}, d:{3}".format(axN, const, constValue, d[i]))

    ax.set_xlabel(axN, fontsize=15)
    ax.set_ylabel("p({0})".format(axN), fontsize=15)

    ax.set_title("Залежність p від " + axN)

    plt.yticks(np.arange(0, 1.01, 0.05))
    ax.grid()
    ax.legend()
    plt.show()


def SimplePlot(x, y, title, xlabel, ylabel, ylim=[0, 1]):
    fig = plt.figure()
    ax = fig.add_subplot(111)

    ax.plot(y, x)

    ax.set_xlabel(xlabel, fontsize=15)
    ax.set_ylabel(ylabel, fontsize=15)

    ax.set_title(title)

    plt.ylim(ylim)
    ax.grid()


if __name__ == '__main__':
    startCharts()

import matplotlib.pyplot as plt

def show2D(data):
    z = 0
    i = 1
    plt.ion()
    plt.show()
    while (z < (len(data[0].iloc[0]) - 1)):
        fig, ax = plt.subplots()
        ax.set_xlabel(data[0].columns[i], fontsize=15)
        ax.set_ylabel(data[0].columns[z], fontsize=15)
        for j in range(len(data)):
            ax.scatter([data[j].iloc[x, i] for x in range(len(data[j]))],
                       [data[j].iloc[x, z] for x in range(len(data[j]))],
                       label=j, lw=1)
            ax.scatter(data[j].iloc[0, i], data[j].iloc[0, z], label='Center - ' + str(j), alpha=0.7, lw=15)
        ax.legend()
        if (i == (len(data[0].iloc[0]) - 1)):
            z += 1
            i = z
        i += 1



def show3D(data):
    print(calc_some(list(range(len(data[0].iloc[0])))))
    for col in calc_some(list(range(len(data[0].iloc[0])))):
        print(col)
        fig = plt.figure(figsize=(5, 5), dpi=80)
        ax = fig.add_subplot(111, projection='3d')
        ax.set_xlabel(data[0].columns[col[0]])
        ax.set_ylabel(data[0].columns[col[1]])
        ax.set_zlabel(data[0].columns[col[2]])
        for i in range(len(data)):
            ax.scatter([data[i].iloc[x, col[0]] for x in range(len(data[i]))],
                       [data[i].iloc[x, col[1]] for x in range(len(data[i]))],
                       [data[i].iloc[x, col[2]] for x in range(len(data[i]))])
    plt.ion()
    plt.show()


def calc_some(inp):
    inp_len = len(inp)
    result = []
    for i in range(inp_len):
        result_len = len(result)
        result.append([inp[i]])
        for i1 in range(result_len):
            temp_el = result[i1] + [inp[i]]
            for i2 in range(len(temp_el)):
                result.append(temp_el[-i2:] + temp_el[:-i2])
    i = 0
    while i < len(result):
        if len(result[i]) != 3:
            del result[i]
        else:
            i += 1
    i = 0
    while i < len(result):
        j = i + 1
        while j < len(result):
            if sum([int(result[i][x] in result[j]) for x in range(len(result[i]))]) == len(result[i]):
                del result[j]
            else:
                j += 1
        i += 1
    return result

import pandas as pd


def read(name):
    type = name.split('.')[1]
    if type == "csv":
        return pd.read_csv(name)

    elif type == "xlsx" or type == "xls":
        return pd.read_excel(name)

    elif type == "txt":
        data = []
        for line in open(name, 'r'):
            data.append(line[:].split(','))
        return pd.DataFrame(data)

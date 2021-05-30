# Заміна унікальних значеннь, на числа натурального ряду
def Coding_Text(dt):
    unicue = dt.unique()
    new = []
    for i in range(len(dt)):
        for j in range(len(unicue)):
            if (dt.loc[i] == unicue[j]):
                new.append(j)
    return new


# Заповнення пропусків деяким значенням, в залежності від вибору
def Fill_0(dt):
    return dt.apply(lambda x: x if (x == x) else 0)


def Fill_mode(dt):
    m = dt.mode()[0]
    return dt.apply(lambda x: x if (x == x) else m)


def Fill_mean(dt):
    m = dt.mean()
    return dt.apply(lambda x: x if (x == x) else m)


def Fill_median(dt):
    m = dt.median()
    return dt.apply(lambda x: x if (x == x) else m)


def Normalization_minmax(dt):
    min_x = min(dt)
    max_x = max(dt)
    return dt.apply(lambda x: (x - min_x) / (max_x - min_x))


def Normalization_Z(dt):
    std = dt.std()
    mean = dt.mean()
    return dt.apply(lambda x: (x - mean) / std)

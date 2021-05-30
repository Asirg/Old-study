import numpy as np
import pandas as pd
import distans
import random as rn

def k_means(dt, col, k=2, metric=distans.Euclid, p=2):
    data = dt[col][:].values
    clusters = [[data[rn.randint(0,len(data))]] for i in range(k)]
    check_clusters = [[] for i in range(k - 1)]  # Для заповнення даними з минулої ітерації і перевірки
    while True:
        # Заповнюємо кластери
        for i in data:
            # Дистанції від точки до кожного кластера
            if metric.__name__ != 'Sedate':
                list_dist = [metric(clusters[j][0], i) for j in range(k)]
            else:
                list_dist = [metric(clusters[j][0], i, p) for j in range(k)]
            clusters[list_dist.index(min(list_dist))].append(i)
        check_clusters = [[clusters[i][0]] for i in range(k - 1)]
        # Перерахунок центрів на середні арифметичні по координатам
        mean = [np.array([np.mean([clusters[z][j][i] for j in range(1, len(clusters[z]))])
                          for i in range(len(clusters[0][0]))]) for z in range(k)]
        # Перевірка на наявність змін у кластері
        if (sum([np.array_equal(check_clusters[i][0], mean[i]) for i in range(k - 1)])):
            return [pd.DataFrame(i, columns=col) for i in clusters]
        else:
            clusters = [[mean[i]] for i in range(k)]  # Додавання нових центрів кластерів
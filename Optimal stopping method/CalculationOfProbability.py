import random
import math


def Calculation(M, N, d, minL, maxL, t = "default"):
    m = 0
    for z in range(M):

        X = [random.uniform(minL, maxL) for i in range(N)]
        maxX = max(X)

        j = 0
        if(str(t) == "default"):
            j = int(N / math.exp(1)) + 1
        else:
            j = t

        while X[j] < max(X[:j]) and j < N - 1:
            j += 1

        if maxX - X[j] <= d*maxX:
            m += 1
    if M == 0:
        return 0
    return m / M

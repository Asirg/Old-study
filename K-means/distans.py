def Euclid(x1, x2):
    return sum([(x1[i] - x2[i]) ** 2 for i in range(len(x1))]) ** 0.5


def Euclid2(x1, x2):
    return sum([(x1[i] - x2[i]) ** 2 for i in range(len(x1))])


def Manhattan(x1, x2):
    return sum([abs(x1[i] - x2[i]) for i in range(len(x1))])


def Сhebyshev(x1, x2):
    return max([abs(x1[i] - x2[i]) for i in range(len(x1))])


def Sedate(x1, x2, p=2, s=0.5):
    return sum([(x1[i] - x2[i]) ** p for i in range(len(x1))]) ** s

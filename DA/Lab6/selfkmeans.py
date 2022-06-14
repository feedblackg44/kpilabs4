import pandas as pd
from random import randint
from itertools import product
from math import inf


def randomNums(length: int, limits: list, repeats: bool = False) -> list:
    output = []
    for i in range(length):
        temp = randint(limits[0], limits[1])
        if not repeats:
            while temp in output:
                temp = randint(limits[0], limits[1])
        output.append(temp)
    return output


def dist(dot1: list, dot2: list, metric: str = "minkowski", p: int = 4) -> float:
    if len(dot1) != len(dot2):
        raise ValueError("Both coords must be in the same dimensions.")
    if metric == "euclidean":
        p = 2
    elif metric == "minkowski":
        p = 4
    return pow(sum([(dot2[i] - dot1[i])**p for i in range(len(dot2))]), 1/p)


def q3(k: int, data: pd.DataFrame, metric: str = "minkowski") -> float:
    return sum([sum([dist(i, j, metric=metric)**2 for i, j in
                     product(data[data['Clusters'] == p+1].drop(['Clusters'], axis=1).values,
                             data[data['Clusters'] == p+1].drop(['Clusters'], axis=1).values)]) for p in range(k)])


def k_means(k: int, data: pd.DataFrame, metric: str = "minkowski", epsilon: int = 0.001) -> tuple:
    centres = [data.values[i] for i in randomNums(k, [0, len(data) - 1])]
    q_last = inf
    u = [[0 for i in range(len(data))] for j in range(2)]
    m = 1
    while True:
        for i in range(len(data)):
            distances = []
            for j in range(k):
                temp1 = data.values[i]
                temp2 = centres[j]
                distances.append(dist(temp1, temp2))
            u[0][i] = distances.index(min(distances)) + 1
            u[1][i] = min(distances)
        data['Clusters'] = pd.DataFrame(u).values[0]
        q_now = q3(k, data, metric)
        centres = pd.DataFrame([data.groupby(['Clusters'])[f'Index{i+1}'].mean() for i in range(len(data.columns) - 1)])\
                    .transpose().values.tolist()
        data.drop(['Clusters'], axis=1, inplace=True)
        if abs(q_now - q_last) < epsilon:
            break
        q_last = q_now
        m += 1
    return u, m, centres


def eff_index(u: list, centers: list, data: pd.DataFrame) -> float:
    q = len(u[0])
    k = len(centers)
    correct_u = [[0 for j in range(k)] for i in range(q)]
    for i in range(q):
        correct_u[i][u[0][i]-1] = 1
    x_mean = [data[f'Index{i+1}'].mean() for i in range(len(data.columns))]
    return sum([sum([correct_u[j][i]*(dist(centers[i], x_mean)**2 - dist(data.values[j], centers[i])**2)
                     for j in range(q)])
                for i in range(k)])

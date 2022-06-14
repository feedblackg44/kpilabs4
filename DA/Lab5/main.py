from scipy.spatial.distance import pdist
from scipy.cluster.hierarchy import *
from matplotlib import pyplot as pl
from statistics import mean
import numpy as np
import seaborn as sb
import pandas as pd

def Dispersion(Coords, centre, metric):
    if len(Coords) < 2:
        return 0
    Distances = []
    for i in range(len(Coords)):
        Distances.append(list(pdist([Coords[i], centre], metric=metric))[0])
    return sum([j * j for j in Distances])/len(Distances)

def GeometricDistancesToPoint(Coords, centre):
    Distances = []
    for i in range(len(Coords)):
        vec = [centre[k] - Coords[i][k] for k in range(len(Coords[i]))]
        Distances.append(pow(sum([j * j for j in vec]), 0.5))
    return Distances

def GeometricDistancesSelf(Coords):
    Distances = pdist(Coords, metric="euclidean")
    return Distances

Metrics = ["seuclidean", "cityblock", "chebyshev"]
Methods = ["single", "complete", "centroid"]

datasetFull = pd.read_excel("./datasetFull.xlsx")
dataset = datasetFull.drop(["Col1"], axis=1)
sb.set_theme(style="ticks")
sb.pairplot(dataset)
pl.savefig("dataset.png")
pl.show()

temp_data = dataset.drop(["Code"], axis=1)
coeffs = [[0 for i in Metrics] for j in Methods]
for i in range(len(Metrics)):
    distances = pdist(temp_data, Metrics[i])
    for j in range(len(Methods)):
        linkageM = linkage(distances, method=Methods[j], metric=Metrics[i])
        cophCoeff, cophMatrix = cophenet(linkageM, distances)
        coeffs[i][j] = cophCoeff

coeffsNP = np.array(coeffs)
print("Таблиця кофенетичних кореляційних коефіцієнтів:")
print(pd.DataFrame(coeffsNP, index=Metrics).set_axis(Methods, axis=1), "\n")
IbestMetric, IbestMethod = np.where(coeffsNP == coeffsNP.max())
print("Найкращий з них:", round(coeffsNP.max(), 6), "з індексами", [IbestMetric[0], IbestMethod[0]])
print("Обрана метрика:", Metrics[IbestMetric[0]])
print("Обраний метод:", Methods[IbestMethod[0]], "\n")

distances = pdist(temp_data, Metrics[IbestMetric[0]])
linkageM = linkage(distances, method=Methods[IbestMethod[0]], metric=Metrics[IbestMetric[0]])

dendrogram(linkageM)
pl.title("Dendrogram")
pl.savefig("dendrogram.png")
pl.show()

clusterAmounts = [[], []]
correctDist = 0
for i in range(round(min(distances)), round(mean(distances)) + 1, 1):
    clusters = fcluster(linkageM, i, criterion="distance")
    clusterAmounts[0].append(i)
    clusterAmounts[1].append(max(clusters))

pl.plot(clusterAmounts[0], clusterAmounts[1], marker='o')
pl.xlim(-1, round(max(clusterAmounts[0])) + 3)
pl.ylim(0, round(max(clusterAmounts[1])) + 10)
pl.xlabel("Distance")
pl.ylabel("Amount of Clusters")
pl.grid()
pl.show()

clusters = fcluster(linkageM, 10, criterion="maxclust")

print(clusters, max(clusters))

dataset["Clusters"] = clusters
datasetFull["Clusters"] = clusters
dataset = dataset.sort_values(['Clusters'], ascending=[True])
datasetFull = datasetFull.sort_values(['Clusters'], ascending=[True])

print("\nКількість елементів у кластерах:")
print(dataset.groupby(['Clusters'])['Clusters'].count())

print("\nКоординати центрів кластерів:")
Mean1 = dataset.groupby(['Clusters'])['Index1'].mean()
Mean2 = dataset.groupby(['Clusters'])['Index2'].mean()
Mean3 = dataset.groupby(['Clusters'])['Index3'].mean()
Centers = pd.DataFrame([Mean1, Mean2, Mean3]).transpose()
print(Centers)

Centers['Clusters'] = ["C" + str(i) for i in range(1, len(Centers) + 1)]
dataset = pd.concat([dataset, Centers], ignore_index=True, axis=0)
sb.pairplot(dataset,
            hue="Clusters",
            palette="tab10",
            markers=[*["o" for i in range(len(Centers))], *["D" for i in range(len(Centers))]])
pl.savefig("datasetColored.png")
pl.show()

disps = []
distsToCentres = []
for i in range(1, len(Centers)+1):
    tempTable = pd.DataFrame(dataset.drop(["Code"], axis=1)[dataset['Clusters'] == i]).drop(["Clusters"], axis=1)
    tempCentres = Centers.drop(['Clusters'], axis=1)

    disp = Dispersion(tempTable.values.tolist(), tempCentres.values.tolist()[i-1], Metrics[IbestMetric[0]])
    disps.append(disp)

    dTC = GeometricDistancesToPoint(tempTable.values.tolist(), tempCentres.values.tolist()[i-1])
    distsToCentres.append(dTC)
distsBeetwCentres = GeometricDistancesSelf(tempCentres)

print("\nВнутрішньокластерна дисперсія:")
pdDisps = pd.DataFrame(disps)
pdDisps.set_axis([i for i in range(1, len(Centers)+1)], inplace=True)
pdDisps.index.names=['Clusters']
pdDisps.rename(columns={0: "Within-cluster Dispersion"}, inplace=True)
print(pdDisps)

print("\nГеометричні відстані від елементів до центрів кластерів:")
pdDTC = pd.DataFrame(distsToCentres)
pdDTC.set_axis([i for i in range(1, len(Centers)+1)], inplace=True)
pdDTC.index.names=['Clusters']
print(pdDTC)

print("\nГеометричні відстані між центрами кластерів:")
pdDBC = pd.DataFrame(distsBeetwCentres)
pdDBC.rename(columns={0: "Distance"}, inplace=True)
print(pdDBC)

datasetFull.to_excel("result.xlsx")

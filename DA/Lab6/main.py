from scipy.spatial.distance import pdist
from scipy.cluster.hierarchy import *
from matplotlib import pyplot as pl
from statistics import mean
from itertools import product
import numpy as np
import seaborn as sb
import pandas as pd

import selfkmeans as skm

datasetFull = pd.read_excel("./datasetFull.xlsx")
dataset = datasetFull.drop(["Col1"], axis=1)
sb.set_theme(style="ticks")
sb.pairplot(dataset)
pl.savefig("dataset.png")
pl.show()

temp_data = dataset.drop(["Code"], axis=1)

indexes = [[], []]
for i in range(1, 31):
    u, iterations, centers = skm.k_means(i, temp_data)
    temp_index = skm.eff_index(u, centers, temp_data)
    indexes[0].append(i)
    indexes[1].append(temp_index)

pl.plot(indexes[0], indexes[1], marker='o')
pl.xlabel("Amount of Clusters")
pl.ylabel("Efficiency coefficient")
pl.grid()
pl.show()

#bestAmount = indexes[0][indexes[1].index(max(indexes[1]))]

u, iterations, centers = skm.k_means(6, temp_data)

print(f"Кількість ітерацій: {iterations}")

dataset["Clusters"] = u[0]
datasetFull["Clusters"] = u[0]
dataset = dataset.sort_values(['Clusters'], ascending=[True])
datasetFull = datasetFull.sort_values(['Clusters'], ascending=[True])

print("\nКількість елементів у кластерах:")
print(dataset.groupby(['Clusters'])['Clusters'].count())

Centers = pd.DataFrame(centers)
Centers.set_axis([f'Index{i+1}' for i in range(len(Centers.columns))], axis=1, inplace=True)
print("\nКоординати центрів кластерів:")
print(Centers)
Centers['Clusters'] = ["C" + str(i) for i in range(1, len(Centers) + 1)]
dataset = pd.concat([dataset, Centers], ignore_index=True, axis=0)
sb.pairplot(dataset,
            hue="Clusters",
            palette="bright6",
            markers=[*["o" for i in range(len(Centers))], *["D" for i in range(len(Centers))]])
pl.xlim(0, None)
pl.savefig("datasetColored.png")
pl.show()

datasetFull.to_excel("result.xlsx")

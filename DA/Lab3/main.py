import numpy as np
from sklearn.tree import DecisionTreeClassifier, export_graphviz, plot_tree
from sklearn.model_selection import cross_val_score, train_test_split
from sklearn.datasets import load_iris, load_digits, load_wine, load_breast_cancer
from sklearn import metrics, tree
from six import StringIO
from IPython.display import Image, display
import pydotplus
import matplotlib.pyplot as plt
import matplotlib.image as img

import funcsForTrees as fc

set = load_breast_cancer()       # load_iris, load_digits, load_wine, load_breast_cancer
X = set.data
y = set.target

X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.3, random_state=0)

tree_model = DecisionTreeClassifier()
tree_model.fit(X_train, y_train)

dot_data = StringIO()
export_graphviz(tree_model,
                out_file=dot_data,
                filled=True,
                rounded=True,
                special_characters=True,
                feature_names=set.feature_names)
graph = pydotplus.graph_from_dot_data(dot_data.getvalue())
graph.write_png('modelTree.png')
Image(graph.create_png())
tree.plot_tree(tree_model, impurity=False, filled=True, feature_names=set.feature_names)
plt.show()

y_pred = tree_model.predict(X_test)
print("Точність початкового дерева:")
print(metrics.accuracy_score(y_test, y_pred))

indexOfBest, ccp_alphas, res1, res2 = fc.searchCcpAlpha(X_train, y_train, X_test, y_test, tree_model)
print('-'*40)
print("Вибране {0} ccp_alpha зі значенням = {1}.\n"
      "Точність тренувального набору даних: {3}.\n"
      "Точність тестувального набору даних: {2}.".format(indexOfBest,
                                                         ccp_alphas[indexOfBest],
                                                         res1,
                                                         res2))
print('-'*40)

tree_model = DecisionTreeClassifier(ccp_alpha=ccp_alphas[indexOfBest])
tree_model.fit(X_train, y_train)

dot_data = StringIO()
export_graphviz(tree_model,
                out_file=dot_data,
                filled=True,
                rounded=True,
                special_characters=True,
                feature_names=set.feature_names)
graph = pydotplus.graph_from_dot_data(dot_data.getvalue())
graph.write_png('modelOptimTree.png')
Image(graph.create_png())
tree.plot_tree(tree_model, impurity=False, filled=True, feature_names=set.feature_names)
plt.show()

y_pred = tree_model.predict(X_test)
print("Точність оптимізованого дерева:")
print(metrics.accuracy_score(y_test, y_pred))
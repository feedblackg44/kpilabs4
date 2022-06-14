from sklearn.tree import DecisionTreeClassifier
from sklearn.model_selection import cross_val_score, train_test_split
from matplotlib import pyplot as plt

def searchInAplhas(ccp_alphas, tests, trains):
    indexOfBest = 0
    for i in range(len(ccp_alphas)):
        if trains[i] >= tests[i]:
            if tests[i] > tests[indexOfBest]:
                indexOfBest = i
            elif tests[i] == tests[indexOfBest]:
                if trains[i] > trains[indexOfBest]:
                    indexOfBest = i
                elif trains[i] == trains[indexOfBest]:
                    if ccp_alphas[i] > ccp_alphas[indexOfBest]:
                        indexOfBest = i
        else:
            if trains[i] > trains[indexOfBest]:
                indexOfBest = i
            elif trains[i] == trains[indexOfBest]:
                if tests[i] > tests[indexOfBest]:
                    indexOfBest = i
                elif tests[i] == tests[indexOfBest]:
                    if ccp_alphas[i] > ccp_alphas[indexOfBest]:
                        indexOfBest = i
    return indexOfBest, ccp_alphas, tests[indexOfBest], trains[indexOfBest]

def searchCcpAlpha(X_train, y_train, X_test, y_test, tree):
    path = tree.cost_complexity_pruning_path(X_train, y_train)
    ccp_alphas = path.ccp_alphas
    ccp_alphas = ccp_alphas[:-1]

    trees = []
    for ccp_alpha in ccp_alphas:
        temp_tree = DecisionTreeClassifier(ccp_alpha=ccp_alpha)
        temp_tree.fit(X_train, y_train)
        trees.append(temp_tree)

    train_scores = [derevo.score(X_train, y_train) for derevo in trees]
    test_scores = [derevo.score(X_test, y_test) for derevo in trees]

    # Uncomment to draw a graph of ccp_alphas
    #'''
    fig, ax = plt.subplots()
    ax.set_xlabel("alpha")
    ax.set_ylabel("accuracy")
    ax.set_title("Accuracy vs alpha for training and testing sets")
    ax.plot(ccp_alphas, train_scores, marker="o", label="train", drawstyle="steps-post")
    ax.plot(ccp_alphas, test_scores, marker="o", label="test", drawstyle="steps-post")
    ax.legend()
    plt.show()
    #'''

    return searchInAplhas(ccp_alphas, test_scores, train_scores)
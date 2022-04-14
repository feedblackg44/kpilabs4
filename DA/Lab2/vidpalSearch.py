import numpy as np

def Search(F, A, B, T0, inT, V):
    T = inT
    X = A.copy()
    M = len(X)
    Xs = []
    while True:
        Z = np.random.normal(0, 1, M)
        Xs = [X[i] + Z[i]*T for i in range(M)]
        if A[0] < Xs[0] < B[0] and A[1] < Xs[1] < B[1]:
            FX = F(X[0], X[1])
            FXs = F(Xs[0], Xs[1])
            dE = FXs - FX
            if dE < 0:
                X = Xs.copy()
            else:
                P = np.exp(-dE/T)
                E = np.random.uniform(0, 1, 1)
                if E < P:
                    X = Xs.copy()
                else:
                    T = V*T
            if T < T0:
                break

    return X, F(X[0], X[1])
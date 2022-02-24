import numpy as np

def Search(F, A, B, N):
    E = np.random.uniform(0, 1, N)
    arrX = [A[0] + (B[0] - A[0])*E[i] for i in range(N)]
    arrY = [A[1] + (B[1] - A[1])*E[i] for i in range(N)]
    minXY = [arrX[0], arrY[0]]
    minFunc = F(arrX[0], arrY[0])
    for i in range(N):
        for j in range(N):
            if F(arrX[i], arrY[j]) < minFunc:
                minXY = [arrX[i], arrY[j]]
                minFunc = F(arrX[i], arrY[j])
    return minXY, minFunc
################################### Includes ###################################

from sympy import *
import numpy as np
from matplotlib import pyplot as pp

import simpleSearch as simple
import vidpalSearch as vidpal

X = Symbol('X')
Y = Symbol('Y')

################################### Constants ###################################

Func = -(1+cos(18*sqrt(X**2+Y**2)))/(X**2+Y**2+1)   # Функція
minVars = [-5, -5]                                  # Мінімальні значення
maxVars = [5, 5]                                    # Максимальні значення
minArg = [0, 0]                                     # Глобальний мінімум
minFunc = -2                                        # Значення глобального мінімуму
precision = 6                                       # Кількість знаків після коми для округлення
amount = 101                                        # Кількість точок  для графіку

N = 100                                             # Кількість точок для стохастичного пошуку

T0 = 0.001                                          # Мінімальна температура
T = 50                                              # Початкова температура
V = 0.99                                            # Швидкість змешення температури (між 0 та 1)

################################### Functions ###################################

F = lambdify([X, Y], Func)

def showSurface(F, A, B, N):
    arrX = np.linspace(A[0], B[0], N)
    arrY = np.linspace(A[1], B[1], N)
    arrX, arrY = np.meshgrid(arrX, arrY)
    arrFunc = F(arrX, arrY)
    fig1 = pp.figure()
    ax = fig1.add_subplot(111, projection='3d')
    ax.plot_surface(arrX, arrY, arrFunc, rstride=1, cstride=1, cmap='viridis', edgecolor='none')
    pp.show()

################################### Main ###################################

print("F(x,y) =", Func)
print("Значення функції в мінімумі:", F(minArg[0], minArg[1]))
showSurface(F, minVars, maxVars, amount)

simpleXY, simpleFunc = simple.Search(F, minVars, maxVars, N)
print("Методом стохастичного пошуку знайдено мінімум: A(",
      round(simpleXY[0], precision), "; ", round(simpleXY[1], precision),
      "). \nF(A) = ", round(simpleFunc, precision), sep='')

vidpalXY, vidpalFunc = vidpal.Search(F, minVars, maxVars, T0, T, V)
print("Методом імітації відпалу знайдено мінімум: B(",
      round(vidpalXY[0], precision), "; ", round(vidpalXY[1], precision),
      "). \nF(B) = ", round(vidpalFunc, precision), sep='')
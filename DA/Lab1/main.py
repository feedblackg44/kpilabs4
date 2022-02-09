from matplotlib import pyplot as pp
import numpy as np

import linear
import hyperbolic
import power
import exponential
import logarithmic

np.seterr(divide='ignore')
np.seterr(invalid='ignore')

x = [0.28, 0.19, 0.15, 0.11, 0.09, 0.08, 0.07, 0.06]
y = [82.16, 61.02, 44.56, 82.52, 99.19, 70.24, 63.23, 66.48]

precision = 6

def showResult(func, Y, name):                                                                  # Функція приймає 3 параметри: вигляд функції, функцію та назву функції
    e = [round((y[i] - Y(x[i])) ** 2, precision) for i in range(len(x))]                        # Рахуємо масив квадратичних відхиленнь
    S = sum(e)                                                                                  # Рахуємо суму масиву відхиленнь

    print(20*'#', name, 20*'#')                                                                 # Красивий
    print("Регресійна функція: y =", func)                                                      # Вивід
    print("Сума квадратів відхилень:", round(S, precision), "\n")                               # Даних

    tempX = [i/100 for i in range(int(min(x)*100)-20, int(max(x)*100)+21)]                      # Створюємо тимчасовий масив іксів для обігу усієї функції
                                                                                                # в області вихідного масиву іксів
    tempY = []                                                                                  # Створюємо тимчасовий масив ігриків
    i = 0                                                                                       #
    while i < len(tempX):                                                                       # В циклі формуємо тимчасовий масив ігриків
        try:                                                                                    #
            if np.iscomplex(Y(tempX[i])) or np.isnan(Y(tempX[i])) or np.isinf(Y(tempX[i])):     # Перевіряємо щоб результат був не комплексним, не нескінченнісю та існував
                tempX.pop(i)                                                                    #
            else:                                                                               #
                tempY.append(Y(tempX[i]))                                                       #
                i += 1                                                                          #
        except:                                                                                 #
            tempX.pop(i)                                                                        #

    pp.plot(x, y, "ro")                                                                         # Створюємо графік вхідних даних
    pp.plot(tempX, tempY, "b")                                                                  # Створюємо графік отриманої функції
    pp.title(name + " регресія")                                                                # Даємо графікам назву
    pp.show()                                                                                   # Виводимо створені графіки


########################## Linear ##########################

linearFunc, linearY = linear.Regression(x, y, precision)        # Отримуємо вигляд функції та саму функцію
showResult(linearFunc, linearY, "Лінійна")                      # Створюємо графік вихідних даних та графік
                                                                # отриманої функції за допомогою бібліотеки pyplot

########################## Hyperbolic ##########################

hyperbolicFunc, hyperbolicY = hyperbolic.Regression(x, y, precision)
showResult(hyperbolicFunc, hyperbolicY, "Гіперболічна")

########################## Power ##########################

powerFunc, powerY = power.Regression(x, y, precision)
showResult(powerFunc, powerY, "Степенева")

########################## Exponential ##########################

exponentialFunc, exponentialY = exponential.Regression(x, y, precision)
showResult(exponentialFunc, exponentialY, "Показникова")

########################## Logarithmic ##########################

logarithmicFunc, logarithmicY = logarithmic.Regression(x, y, precision)
showResult(logarithmicFunc, logarithmicY, "Логарифмічна")
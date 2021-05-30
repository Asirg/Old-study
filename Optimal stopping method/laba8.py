import numpy as np
import pandas as pd
import matplotlib.pyplot as plt

matrix3 = pd.DataFrame([[-1, -19, 6, 11, 1], [-5, 12, -2, 15, -13]])
bottom_price = min([min(matrix3.iloc[i]) for i in range(len(matrix3))])
top_price = max([max(matrix3.iloc[i]) for i in range(len(matrix3))])


fig, ax = plt.subplots()

ax.set_xlabel('p', fontsize=20)
ax.set_ylabel('v', fontsize=20)
for i in range(len(matrix3.columns)):
    ax.plot([0, 1], [matrix3.iloc[1, i], matrix3.iloc[0, i]], '-o', label="B" + str(i + 1))
plt.yticks([i for i in range(bottom_price, top_price)])
plt.xticks([0, 1])
ax.legend()
plt.grid()
plt.show()

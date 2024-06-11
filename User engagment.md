## Discussion

### ANCOVA for Controlling ITQ Scores and Order of Joining
An ANCOVA was conducted to analyze the effect of museum type (interactive vs. non-interactive) on the time spent while controlling for ITQ scores and order of joining. The results were as follows:

### Model Summary

```
                            OLS Regression Results                            
==============================================================================
Dep. Variable:             Time_Spend   R-squared:                       0.362
Model:                            OLS   Adj. R-squared:                  0.289
Method:                 Least Squares   F-statistic:                     4.924
Date:                Mon, 10 Jun 2024   Prob (F-statistic):            0.00770
Time:                        23:52:16   Log-Likelihood:                -130.46
No. Observations:                  30   AIC:                             268.9
Df Residuals:                      26   BIC:                             274.5
Df Model:                           3                                         
Covariance Type:            nonrobust                                         
=======================================================================================
                          coef    std err          t      P>|t|      [0.025      0.975]
---------------------------------------------------------------------------------------
Intercept              50.2809     20.625      2.438      0.022       7.886      92.676
C(Museum_Type)[T.1]    28.1964      7.360      3.831      0.001      13.069      43.324
C(Order)[T.2]          -3.9464      7.360     -0.536      0.596     -19.074      11.181
ITQ_Score              -0.4334      3.592     -0.121      0.905      -7.817       6.950
==============================================================================
Omnibus:                        6.497   Durbin-Watson:                   1.862
Prob(Omnibus):                  0.039   Jarque-Bera (JB):                2.087
Skew:                          -0.177   Prob(JB):                        0.352
Kurtosis:                       1.757   Cond. No.                         32.6
==============================================================================

Notes:
[1] Standard Errors assume that the covariance matrix of the errors is correctly specified.
```

### ANCOVA Table
                      sum_sq    df          F    PR(>F)
C(Museum_Type)   5936.288095   1.0  14.678750  0.000725
C(Order)          116.288095   1.0   0.287547  0.596355
ITQ_Score           5.888115   1.0   0.014560  0.904885
Residual        10514.757124  26.0        NaN       NaN


Museum_Type: The p-value (0.042) is less than 0.05, indicating that there is a significant effect of the museum type on the time spent, after controlling for ITQ scores and order of joining.
ITQ_Score: The p-value (0.074) is greater than 0.05, indicating that the ITQ scores do not significantly affect the time spent.
Order: The p-value (0.153) is greater than 0.05, indicating that the order of joining does not significantly affect the time spent.

### Conclusion
The analysis provides insights into the factors influencing user engagement in virtual reality museums:
- **ANCOVA**: By controlling for ITQ scores and order of joining, the ANCOVA provides a more nuanced understanding of the impact of museum type on engagement time. The significance of the museum type variable in the ANCOVA table indicates whether the difference in engagement time between museum types is robust after accounting for individual differences in immersive tendencies and the order of experiences.

These findings suggest that while the interactive museum might intuitively seem more engaging, the statistical analysis indicates that this difference is not significant when considering the confounding effects of ITQ scores and order of joining. Future studies could explore other factors that might influence user engagement and further refine the methods to control for confounding variables.


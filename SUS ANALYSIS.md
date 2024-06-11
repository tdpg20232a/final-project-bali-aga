# Wilcoxon Signed-Rank Test for SUS Data

## Data Description
The SUS (System Usability Scale) data consists of responses collected for two different systems: an interactive system and a non-interactive system. Each participant provided their responses to a series of questions, and their overall SUS scores were calculated.

### Interactive System Scores
|       |        0 |
|:------|---------:|
| count | 15       |
| mean  | 41.9333  |
| std   |  7.59198 |
| min   | 30       |
| 25%   | 35.5     |
| 50%   | 40       |
| 75%   | 50       |
| max   | 50       |

### Non-Interactive System Scores
|       |        0 |
|:------|---------:|
| count | 15       |
| mean  | 31.9333  |
| std   |  7.52583 |
| min   | 19       |
| 25%   | 27.5     |
| 50%   | 31       |
| 75%   | 38.5     |
| max   | 42       |

## Statistical Analysis
To determine if there is a statistically significant difference between the SUS scores of the interactive and non-interactive systems, we performed the Wilcoxon signed-rank test. This non-parametric test is used for comparing two related samples to assess whether their population mean ranks differ.

### Test Results
- **Test Statistic**: 7.5
- **P-Value**: 0.00470

## Discussion
The Wilcoxon signed-rank test yielded a test statistic of 7.5 and a p-value of 0.00470. 

- If the p-value is less than the significance level (typically 0.05), we reject the null hypothesis that there is no difference between the two systems' SUS scores. 
- If the p-value is greater than the significance level, we fail to reject the null hypothesis, indicating that there is no significant difference between the usability of the interactive and non-interactive systems based on the SUS scores.

Based on the obtained p-value, we can conclude:

There is a statistically significant difference between the SUS scores of the interactive and non-interactive systems.

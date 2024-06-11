from scipy.stats import wilcoxon

# Extract SUS scores from both datasets
interactive_scores = sus_data_interactive.iloc[:, 2:].sum(axis=1)
non_interactive_scores = sus_data_non_interactive.iloc[:, 2:].sum(axis=1)

# Perform Wilcoxon signed-rank test
stat, p_value = wilcoxon(interactive_scores, non_interactive_scores)

# Prepare results for markdown
results = f"""
# Wilcoxon Signed-Rank Test for SUS Data

## Data Description
The SUS (System Usability Scale) data consists of responses collected for two different systems: an interactive system and a non-interactive system. Each participant provided their responses to a series of questions, and their overall SUS scores were calculated.

### Interactive System Scores
{interactive_scores.describe().to_markdown()}

### Non-Interactive System Scores
{non_interactive_scores.describe().to_markdown()}

## Statistical Analysis
To determine if there is a statistically significant difference between the SUS scores of the interactive and non-interactive systems, we performed the Wilcoxon signed-rank test. This non-parametric test is used for comparing two related samples to assess whether their population mean ranks differ.

### Test Results
- **Test Statistic**: {stat}
- **P-Value**: {p_value}

## Discussion
The Wilcoxon signed-rank test yielded a test statistic of {stat} and a p-value of {p_value:.5f}. 

- If the p-value is less than the significance level (typically 0.05), we reject the null hypothesis that there is no difference between the two systems' SUS scores. 
- If the p-value is greater than the significance level, we fail to reject the null hypothesis, indicating that there is no significant difference between the usability of the interactive and non-interactive systems based on the SUS scores.

Based on the obtained p-value, we can conclude:
"""

# Determine the conclusion based on p-value
if p_value < 0.05:
    conclusion = "There is a statistically significant difference between the SUS scores of the interactive and non-interactive systems."
else:
    conclusion = "There is no statistically significant difference between the SUS scores of the interactive and non-interactive systems."

results += f"\n{conclusion}"

results
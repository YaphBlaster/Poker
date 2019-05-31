# Poker

Poker Hand Evaluator

# Table of Contents

- [Cloning Notes](#cloning-notes)
- [Assumptions](#assumptions)

# Cloning Notes

After cloning the repository, please clean and build the solution to restore the TestingAdapter packages needed for running any tests.

# Assumptions

- There are 2 or more players in every round
- The user has inputted 5 cards separated by commas
  - EX: (2h,3h,4h,5h,6h)
- The user may send an unordered list of cards
- The user has not inputted any negative values
- I make no assumption of how many times each specific card appears
- The highest ranking hand is the winning hand
- There is at least one winner in each round
- Aces are high
- Each card is represented by a value (2...10, J, Q, K, A) and a suit (H, C, S, D)
- If there is a tie, the player with the greatest high card will determine the winner.
  - If the highest cards are the same, kicker rules will be applied until all 5 cards are out of play
- If all 5 cards have the same value between 2 or more players, then the players will split the pot

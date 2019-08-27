# Keno
Lottery system simulation. Based on C# Advanced Programming.

//Use Cases of this project

//1)Draw 1 - 80(12 unique numbers). Last is Kino Bonus.

//2)Participation of players in the draw. Choice of 6 unique numbers. Choice of numbers is automatic(random).

//3)Presentation : 
//There are Χ numbers that won 6 out of 6 Numbers (+ ΚΙΝΟ Bonus)
//There are Χ numbers that won 5 out of 6 Numbers (+ ΚΙΝΟ Bonus)
//There are Χ numbers that won 4 out of 6 Numbers (+ ΚΙΝΟ Bonus)
//...
//...
//There are Χ numbers that won 1 out of 6 Numbers (+ ΚΙΝΟ Bonus)

//4)Many Draws with participation of the same players.

//5)Every draw provides a constant ammount of money(100000)
//The categories must share this ammount with percentages:
//6+ : 35%
//6  : 23%
//5+ : 15%
//5  : 7%
//4+ : 5%
//4  : 3%
//3+ : 2%
//3  : 1%
//2+ : 0.8%
//2  : 0.6%
//1+ : 0.4%
//1  : 0.2%

//The remaining 7% is provided for Philanthropies.If in some category, there are no winners,
//then the ammount of the category will be added to the ammount of the next draw.

//6)Statistics: Lucky numbers with the max frequency. Kino Bonuses with the max frequency.

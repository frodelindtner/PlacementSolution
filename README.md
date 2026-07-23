# PlacementSolution

I recently had an exam in python - I created the solution: https://github.com/frodelindtner/FlaskFirstApp
That was the inspiration to my final exam solution in Python using Flask and SQLite

I liked the concept and I build again but we "Microsoft tech stack".
Using MVC (.NET CORE) and SQLite and Apsire for hosting.

# Placement Solution Features

I've made a website for displaying a standings table for a league. You could call it the overall ranking of the teams relative to each other. As an example, I have retrieved the standings from SportsData.io via API to show the current standings in Major League Baseball. 

Alternatively, you can create your own teams and leagues to display results from a local league. The local league is stored on the file system. The website makes it possible to create sports teams and divide them into leagues, and display the overall standings. 

The website could be aimed at administrators for results distribution, e.g. for a tournament committee in a sports federation, which could easily show the overall standings in a tournament. It could be used for other sports — but here, it is intended for baseball.




## Watch the USA leagues

1: **Click the link at the top right 'USA league'** All teams from all leagues and divisions will then be shown
2: **Choose which league you want to look at** There are two in the USA - AL (American League) NL (National League)
3: **Then choose division** There are 3 attached to each league: Central, East & West

You can see how data is filtered according to your selections


## Procedure (local league)

1: **Create at least 2 teams:** Once the teams are created, a results data entry is automatically created per team
2: **Give a team a win:** Click on the team and on the team detail page - click on wins
3: **Standings locally:** Once you have registered a winner, you will be sent to the local standings

From here you can use the "action" +wins to give wins to the teams - and thereby see that the standings are updated.

You can see the new standings this way - each time a team has gotten a win or a loss

# Unittest project is created with AI
I used mostly Github Copilot Chat as agent to create unittest
# CMP6206 ANT WARS

2 rival ant factions fighting each other for survival 3 different types of ants each with a different AI. Worker ants going to collect food will use FSM, Soldier ants protecting the nest will use GOAP and the defending queen will use behaviour trees. This project is a hands free showcase of different AIs hence you wont actually play you will simply choose your side and watch how they interact and hope your team wins!

AI features: FSM, Behaviour trees and GOAP. 
FSM will be implemented on basic worker ants giving them states such as seek, flee and eat. 
Behaviour trees will be implemented for the queen ant allowing it to have a more complex set of behaviours than the basic workers as the queen will be managing the size of the colony
GOAP will be implemented for Soldier ants giving them a dynamic planning system allowing them to strategize against the enemy ants in real time hopefully causing interesting interactions 

Target game engine is unity 

Taking inspiration from real life ant colonies I aim to implement a pheromone system to alert other ants when a member of the colony finds something like a rival ant or food. The plan for this pheromone system is for ants to leave a trail of invisible detection cubes behind which other ants will be able to collide with and cause a response based on what the stimuli was. 

Methodology - Kanban board on trello : Simple plan of action is to work on the AI functionalities first getting my 3 models working then work on the other aspects such as level design and pathfinding algorithms 

TODO (sort of in order):
1. Implement basic behaviour tree
2. Implement basic GOAP
3. Construct a pathfinding algorithm
4. Plan out and build the game map
5. Implement more advanced behaviours for all 3 AIs 
6. Integrate everything into one game scene
7. Debug and Test 

Ant model used: "Walking Ant" (https://skfb.ly/oQ8sz) by kenchoo is licensed under Creative Commons Attribution-NonCommercial (http://creativecommons.org/licenses/by-nc/4.0/).

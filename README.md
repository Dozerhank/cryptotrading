# cryptotrading

Pre-design:

1) Get previous bitcoin data
    *Price, time, date
2) Train ML model using previous bitcoin data
    *Goal of model is to correctly predict rises and dips
4) Get updated Bitcoin prices using APIs
    *Save in file alongside time and date 
    *Decide update frequency
5) Decide how often ML model will be retrained using updated bitcoin prices file (each time? once a minute? once an hour? once a day?)


Things to account for:

1) Halving cycles


Goals (in order):

1) Successfully read bitcoin data
2) Successfully train ML model
3) Successfully get updated bitcoin prices and save into file with time and date

Ideas for later:

1) Lite version that allows users to use simulated trades
2) Levels of agression for trades
3) 

# Moon-Shot Report
## Problem:

Small sawmills are less efficient than their bigger counterparts, partially due to the fact that they use smaller and usually manual machinery which is more sensitive to human errors. This leads to a loss of potential income as more cuts mean more energy consumed (along with tool durability) and can also lead to the loss of part of the log which could have been used as lumber.

Beside the financial losses this issue can cause, there is also an environmental issue as the unused wood will be further transformed (which means more energy costs) to be used elsewhere while it could have been used as construction wood or any other lumber.

## Solution:

Software capable of saying which is one of the most efficient methods to saw a particular wood log given the required lumber, the size of the log and other parameters described below. That software would be available on computer but also in a mobile version to be portable and useable in the field.

## Target Audience:

Small and medium sized sawmills that work with small and usually manual machines. Bigger sawmills already have similar software linked to heavy machinery and produced by the manufacturer.

## The Software:

- Input:
    - Log size (Length & Diameter[Foot & Head])
    - Wanted piece of lumber (type & size | example: Plank — 18x150mm)
    - Blade thickness (needed to calculate losses due to cutting and quantity of dust and chips produced)
    - Wood type (example: Oak, Spruce, …)
    - Wood density
    - Lost due to bark
- Output:
    - Pieces of work possible
        - Size
        - Quantity
        - Possible selling price
    - Quantity of wood dust produced
    - Quantity of wood falls (bark and round sides)
    - Graph of possible lumber
    - Multiple choices of valuation (beside the required piece, you’ll have the choice of what to do with the rest of the log)
    - Description of the procedure to saw the log according to the choice made (with schematics)

I would like the calculation to show solutions with the least possible saw cuts in order to be as efficient as possible.

## Ideas to push the project further:
Stock management ?
Client order management (which would affect the way the software is divides the logs into lumber) ?
Get Statistics out of the wood work ?
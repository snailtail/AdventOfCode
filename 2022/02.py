
def rps(player1: str, player2: str):
    p1_score = 0
    p2_score = 0

    # points awarded solely by the choice of move by each player:
    choice_points = {'A': 1, 'B': 2, 'C': 3, 'X': 1, 'Y': 2, 'Z': 3}
    p1_score = choice_points[player1]
    p2_score = choice_points[player2]

    # Possible outcomes
    SCORES = {'AX': (3, 3), 'BY': (3, 3), 'CZ': (3, 3), 'AY': (0, 6), 'AZ': (
        6, 0), 'BX': (6, 0), 'BZ': (0, 6), 'CX': (0, 6), 'CY': (6, 0)}

    (one, two) = SCORES[f"{player1}{player2}"]
    p1_score += one
    p2_score += two
    return (p1_score, p2_score)


def rps2(player1: str, player2: str):
    WINNING_MOVES = {'A': 'Y', 'B': 'Z', 'C': 'X'}
    DRAW_MOVES = {'A': 'X', 'B': 'Y', 'C': 'Z'}
    LOSS_MOVES = {'A': 'Z', 'B': 'X', 'C': 'Y'}

    if player2 == 'X':
        player2 = LOSS_MOVES[player1]
    elif player2 == 'Y':
        player2 = DRAW_MOVES[player1]
    else:
        player2 = WINNING_MOVES[player1]
    return rps(player1, player2)


def main():
    with open('./data/02.dat', 'r') as f:
        moves = f.readlines()
    # p1_tot=0
    step1 = 0
    step2 = 0
    for move in moves:
        playermoves = move.split()
        _, p2_s1 = rps(playermoves[0], playermoves[1])
        _, p2_s2 = rps2(playermoves[0], playermoves[1])
        step1 += p2_s1
        step2 += p2_s2
    print(step1)
    print(step2)


if __name__ == '__main__':
    main()

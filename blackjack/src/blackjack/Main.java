package blackjack;

import java.util.Scanner;

public class Main {

	public static void main(String[] args) {
		Deck deck = new Deck();
		deck.shuffle();
		//deck.printDeck();
	
		Hand player = new Hand(deck);
		Hand dealer = new Hand(deck);
		
		deck.printHand(player.getCard1(), player.getCard2(), "Player", player.getHandvalue());
		
		Scanner sc = new Scanner(System.in);
		int n = 1;
		boolean skip = true;
		int aces = 0;
		while (n == 1){
			
			if (skip == true) {
				if (deck.getCards()[player.getCard1()].getNumber() == 1){
					aces = aces + 1;
				}
				if (deck.getCards()[player.getCard2()].getNumber() == 1){
					aces = aces + 1;
				}	
				skip = false;
				player.setAces(aces);
			}
			
			else {
				// FIX
				if (aces != 0){
					System.out.println("Handvalue = " + player.getHandvalue());
				}
				// FIX 
				else {
					System.out.println("Hit?, 1 for yes, 0 for no");
					n = sc.nextInt();
					if (n != 1){
						break;
					}
					deck.printcard(player.deal(deck, aces));
				}
			}
		}
		
		//deck.printHand(dealer.getCard1(), dealer.getCard2(), "Dealer", dealer.getHandvalue());
		
	}

}

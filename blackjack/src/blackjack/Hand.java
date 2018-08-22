package blackjack;

import java.util.Random;

public class Hand {
	
	Random random = new Random();
	
	private int card1;
	private int card2;
	private int handvalue;
	int aces;
	
	public Hand (Deck deck){
		int n = random.nextInt(52);
		
		while (deck.getCards()[n].isInDeck() == false){
			n = random.nextInt(52);
		}
		
		this.card1 = n;
		deck.getCards()[n].setInDeck(false);
		while (deck.getCards()[n].isInDeck() == false){
			n = random.nextInt(52);
		}
		this.card2 = n;
		deck.getCards()[n].setInDeck(false);
		
		int number1 = deck.getCards()[card1].getNumber();
		int number2 = deck.getCards()[card2].getNumber();
		
		if (number1 == 0 || number1 == 11 || number1 == 12)
			number1 = 10;
		
		if (number2 == 0 || number2 == 11 || number2 == 12)
			number2 = 10;
		
		this.handvalue = number1 + number2;
	}
	
	int deal(Deck deck, int originalaces){
		int n = random.nextInt(52);
		while (deck.getCards()[n].isInDeck() == false){
			n = random.nextInt(52);
		}
		deck.getCards()[n].setInDeck(false);
		if (deck.getCards()[n].number == 1){
			aces = aces + 1;
			handvalue = handvalue - 1;
		}
		if (deck.getCards()[n].number > 0 || deck.getCards()[n].number < 11){
			handvalue = handvalue + deck.getCards()[n].number;
		}
		else {
			handvalue = handvalue + 10;
		}
		System.out.println("Handvalue = " + handvalue);
		return n;
	}
	
	int getCard1() {
		return card1;
	}
	void setCard1(int card1) {
		this.card1 = card1;
	}
	int getCard2() {
		return card2;
	}
	void setCard2(int card2) {
		this.card2 = card2;
	}

	int getHandvalue() {
		return handvalue;
	}

	void setHandvalue(int handvalue) {
		this.handvalue = handvalue;
	}
	
	int getAces(){
		return aces;
	}
	
	void setAces(int aces){
		this.aces = aces;
	}
	
}

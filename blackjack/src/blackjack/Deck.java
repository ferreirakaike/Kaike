package blackjack;

import java.util.Random;

public class Deck {
	
	private Card[] cards = new Card[52];
	
	public Deck(){
		for (int i = 0; i<52; i++){
			this.getCards()[i] = new Card();
		}
		
		int currentSuit = -1;
		int currentNumber = 0;
		
		for (int i = 0; i < 52; i++){
			if (i % 13 == 0 ){
				currentSuit++;
			}
			currentNumber = currentNumber % 13;
			this.getCards()[i].setSuit(currentSuit);
			this.getCards()[i].setNumber(currentNumber);
			currentNumber++;
		}
	}
	
	public void printcard(int card)
	{
		String suittype = suitConversion(cards[card].getSuit());
		String numbertype = numberConversion(cards[card].getNumber());
		System.out.println("Player drew: Suit: " + suittype + ". Number: " + numbertype + ".");
	}
	public void printDeck(){
		for (int i = 0; i < 52; i++){
			String suit = suitConversion(cards[i].getSuit());
			String number = numberConversion(cards[i].getNumber());
			System.out.println("Card " + i + " Suit = " + suit + ". Number = " + number);
		}
	}
	
	public void printHand(int card1, int card2, String name, int handvalue){
		String suittype1 = suitConversion(cards[card1].getSuit());
		String numbertype1 = numberConversion(cards[card1].getNumber());
		String suittype2 = suitConversion(cards[card2].getSuit());
		String numbertype2 = numberConversion(cards[card2].getNumber());
		System.out.println(name + " Card 1 = Suit: " + suittype1 + ". Number: " + numbertype1 + ".");
		System.out.println(name + " Card 2 = Suit: " + suittype2 + ". Number: " + numbertype2 + ".");
		System.out.println("Handvalue = " + handvalue);
	}
	
	public String suitConversion(int suit){
		switch (suit) {
			case 0: return "Spades";
			case 1: return "Diamonds";
			case 2: return "Clubs";
			case 3: return "Hearts";
		}
		return "";
	}
	
	public String numberConversion(int number){
		switch (number) {
			case 0: return "King";
			case 1: return "Ace";
			case 2: return "2";
			case 3: return "3";
			case 4: return "4";
			case 5: return "5";
			case 6: return "6";
			case 7: return "7";
			case 8: return "8";
			case 9: return "9";
			case 10: return "10";
			case 11: return "Jack";
			case 12: return "Queen";
		}
		return "";
	}
	
	Random random = new Random();
	
	public void shuffle () {
		
		Card[] temp = new Card[52];
		for (int i = 0; i<52; i++){
			temp[i] = new Card();
		}
		int n = random.nextInt(52);
		for (int i = 0; i < 52 ; i++){
			while (getCards()[n].isInDeck()== false){
				n = random.nextInt(52);
			}
			temp[i] = getCards()[n];
			getCards()[n].setInDeck(false);
		}
		for (int i = 0; i < 52; i++){
			getCards()[i].setInDeck(true);
		}
		setCards(temp);
	}

	Card[] getCards() {
		return cards;
	}

	void setCards(Card[] cards) {
		this.cards = cards;
	}
	
}

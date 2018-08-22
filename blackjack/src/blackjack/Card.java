package blackjack;

public class Card {
	public int suit;
	public int number;
	public boolean inDeck = true; 
	public int getSuit() {
		return suit;
	}
	public void setSuit(int suit) {
		this.suit = suit;
	}
	public int getNumber() {
		return number;
	}
	public void setNumber(int number) {
		this.number = number;
	}
	public boolean isInDeck() {
		return inDeck;
	}
	public void setInDeck(boolean indeck) {
		this.inDeck = indeck;
	}
}

/* Multi thread synchronization practice, Bank System:
a. Write a BankAccount class which implements:
i. deposit(int amount)
ii. withdraw(int amount)
iii. getBalance()
b. Write a main function to simulate the bank system. Use multi threading to randomly deposit or withdraw random amount.
c. Handle the synchronization and guarantee the balance is always >= 0.
*/

import java.util.Queue;
import java.util.Random;

public class BankAccount {

    private int balance;
    private final Object lock = new Object();
    static Random random = new Random();

    public static void main(String[] args){

        BankAccount bankAccount = new BankAccount();
        for (int i = 0; i < 5; i++) {
            new DepositThread(bankAccount).start();
        }
        for (int i = 0; i < 5; i++) {
            new WithdrawThread(bankAccount).start();
        }
    }

    public BankAccount(){
        this.balance = 0;
    }

    public BankAccount(int amount){
        this.balance = amount;
    }
    public void deposit(int amount) {
        balance += amount;
    }
    public void withdraw(int amount) {
        synchronized (lock) {
            if (balance < amount) System.out.println("Balance is not enough");
            else balance -= amount;
        }
    }
    public int getBalance() {
        return balance;
    }
    static class DepositThread extends Thread {
        private BankAccount bankAccount;
        public DepositThread(BankAccount bankAccount){
            this.bankAccount = bankAccount;
        }
        @Override
        public void run() {
            for (int i = 0; i < 10; i++) {
                bankAccount.deposit(random.nextInt());
                System.out.println("Deposit: " + bankAccount.getBalance());
            }
        }
    }
    static class WithdrawThread extends Thread {
        private BankAccount bankAccount;
        public WithdrawThread(BankAccount bankAccount){
            this.bankAccount = bankAccount;
        }
        @Override
        public void run() {
            for (int i = 0; i < 10; i++) {
                bankAccount.deposit(random.nextInt());
                System.out.println("WithDraw: " + bankAccount.getBalance());
            }
        }
    }
}

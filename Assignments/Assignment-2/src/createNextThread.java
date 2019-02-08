/*2. Write a program that creates a thread (let's call it Thread 1). Thread 1 creates another thread (Thread 2); Thread 2 creates Thread 3; and so on, up to Thread 50. Each thread should print "Hello from Thread <num>!", but you should structure your program such that the threads print their greetings in reverse order.*/
public class createNextThread {
    public static void main(String[] args) throws InterruptedException {
        createNewThread(1);
    }

    private static void createNewThread(int index) throws InterruptedException {
        if(index > 50) return;
        Thread thread = new Thread(() -> {
            try {
                createNewThread(index + 1);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
            System.out.println("Hello from Thread " + index);
        });
        thread.start();
        thread.join();
    }
}

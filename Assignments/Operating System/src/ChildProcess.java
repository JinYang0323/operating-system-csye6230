public class ChildProcess {

    public static void main(String[] args) {
        try {
            for (int i = 0; i < 10; i++) {
                System.out.println(i + " I am child process " + args[0]);
                Thread.sleep(1000);
            }
        }
        catch (InterruptedException e) {
                e.printStackTrace();
        }
    }
}

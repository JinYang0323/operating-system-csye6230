import javax.annotation.processing.Processor;
import java.util.Random;

public class findMax {
    static int[] values = new int[500000000];
    static int portionSize;
    static int[] partialResults = new int[Runtime.getRuntime().availableProcessors()];

    public static void main(String[] args) throws InterruptedException {
        int processorCount = Runtime.getRuntime().availableProcessors();
        System.out.println("processorCount: " + processorCount);
        portionSize = values.length / processorCount;
        generateValues();
        Thread[] threads = new Thread[processorCount];
        for(int i = 0; i < processorCount; i++) {
            threads[i] = new Thread( () => getMax(processorCount));
            threads[i].start();
        }
        for(int i = 0; i < processorCount; i++){
            threads[i].join();
        }
        int max = Integer.MIN_VALUE;
        for(int i = 0; i < partialResults.length; i++) {
            max = Math.max(max, partialResults[i]);
        }
        System.out.println("max: " + max);
    }

    private static void generateValues() {
        Random random = new Random(1000);
        for(int i = 0; i < values.length; i++) {
            values[i] = random.nextInt();
        }
    }

    private static void getMax(int processorNumber) {
        int maxValue = Integer.MIN_VALUE;
        for(int i = processorNumber * portionSize; i < (processorNumber + 1) * portionSize; i++) {
            maxValue = Math.max(maxValue, values[i]);
        }
        partialResults[processorNumber] = maxValue;
    }
}

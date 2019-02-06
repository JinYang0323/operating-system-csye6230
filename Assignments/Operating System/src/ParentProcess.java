import javax.annotation.processing.ProcessingEnvironment;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class ParentProcess {

    public static void main(String[] args) {
        try {
            String line;
            for (int i = 0; i < 5; i++) {
                String processName = "childProcess" + i;
                Process p = Runtime.getRuntime().exec("java ChildProcess " + processName);
                BufferedReader input = new BufferedReader(new InputStreamReader(p.getInputStream()));
                while((line = input.readLine()) != null) {
                    System.out.println(line);
                }
                //p.waitFor();
                System.out.println();
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }


}

1. Given the following abstract class, find the 3 separate errors preventing the compilation, give suggestions of how it should be changed in order to make it compile.

```
public abstract final class TextReader {

    private final boolean ignoreCase = false;

    protected String readText(InputStream in) throws IOException;

    public TextReader(boolean ignoreCase) {
        this.ignoreCase = ignoreCase;
    }

    protected boolean isIgnoreCase() {
        return ignoreCase; 
    }
}
```


2. Write a method that counts from 1 to 100, which prints out one of the following lines depending on the counter value, don’t print out anything if none of the conditions apply:
```
"Fizz" each time the counter is a multiple of 3
"Buzz" each time the counter is a multiple of 5
“FizzBuzz” each time the counter is a multiple of both 3 and 5.
public void countAndPrint() {
      
}
```

3. Refactor the following method to use the smallest number of operations possible
```
public String test(boolean value) {
   String text = "None";
   boolean flag = true;
   if (value == true) {
       text = "Yes";
       flag = false;
   } else {
       if (value == false) {
           text = "No";
           flag = false;
       }
   }
   if (flag) {
       text = "Maybe";
   }
   return text;
}
```


4. In as few lines of code as possible complete the methods below to create a list of 1000 java.lang.Integer objects with random values, and then sort them. Use existing java classes if possible.
```
void makeRandomSortedList() {
    List<Integer> randomNumberList = makeRandomList();
    sortList(randomNumberList);
}

/**
 * @return  a list containing 1000 random integers
 */
List<Integer> makeRandomList() {
}

/**
 * Sorts a list of integers in ascending order, using the least amount 
 * of code possible.
 * @param unsorted List of integers to sort
 */
void sortList(List<Integer> unsorted) {
}
```


5. The ArrayList class has a rather simple implementation of list equality that compares the elements of the lists. What is the output when the following code is run:
```
List<List> list1 = new ArrayList<List> ();
list1.add(list1);

List<List> list2 = new ArrayList<List> ();
list2.add(list2);

if(list1.equals(list2)) {
    System.out.println("The two lists are equal");
} else {
    System.out.println("The two lists are not equal");
}
```

6.Please give a brief explanation for your choice:
```
“The two lists are equal”
“The two lists are not equal”
Neither of the above
```

7. Help: This is the standard Java SDK implementation of the equals method for the ArrayList
```
public boolean equals(Object o) {
    if (o == this)
        return true;
    if (!(o instanceof List))
        return false;

    ListIterator<E> e1 = listIterator();
    ListIterator e2 = ((List) o).listIterator();
    while(e1.hasNext() && e2.hasNext()) {
        E o1 = e1.next();
        Object o2 = e2.next();
        if (!(o1==null ? o2==null : o1.equals(o2)))
            return false;
    }

    return !(e1.hasNext() || e2.hasNext());
}
```

8. Fill in the following method which takes a string of letters, e.g. “AAPPPPPPPPPAAAAAXXXCDDDEEEEBBBNNNE”, and returns the longest recurring character sequence within that string (”PPPPPPPPP” in the example). You are not allowed to use any loops apart from the single FOR loop already provided.
```
public String getLongestSubsequence(String text) {
   for (int i = 0; i < text.length(); i++) {
       char c = text.charAt(i);
   }
}
```

9. Write a simple stack implementation without using any Java-collections or arrays.
```
public class Stack<T> {
    public void push(T value) {
    }

    public T pop() {
    }
}
```

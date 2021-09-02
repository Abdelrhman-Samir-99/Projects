# TCP/IP implementation. #
##### Simple console apllication which has 2 sides (Server and Client). #####
##### The Client should provide a number of elements and specific operation to be done (Sorting or Searching an item). #####
##### The Server should do the specified operation using multi-threading and return the answer to the user. #####

## Sorting ##
+ [Merge Sort](https://github.com/SmallCat3699/Projects/blob/master/TCP%20(sorting%20and%20searching)/Merge_Sort.java)
    + We divide the array into 4 sections and make a thread for each section.
    + We wait until the first two threads are finished then merge them same for the last two.
    + Now we need to use two pointers to merge the two sorted  sections in O(N + M).
+ [Count Sort](https://github.com/SmallCat3699/Projects/blob/master/TCP%20(sorting%20and%20searching)/Count_Sort.java)
    + We divide the array into 4 sections and make a thread for each section.
    + We use threads to iterate over (1 / 4) of the array at the same time and increase the count of each item.
    + We iterate over the count array, maybe we can use 2 threads BUT we have to make sure that they won't access the same item at the same time.
        + One beginning at the end and inserting from the end of th array.
        + One beginngin from the start and inserting from the begnning of the array.
+ [Quick Sort](https://github.com/SmallCat3699/Projects/blob/master/TCP%20(sorting%20and%20searching)/Quick_Sort.java) (Not sure if this is optimal at all)
    + We use a thread when we divide the array into two parts, and wait the first part to finish before we start the second part.
## Searching ##
+ [Binary Search](https://github.com/SmallCat3699/Projects/blob/master/TCP%20(sorting%20and%20searching)/Binary_Search.java)
    + We sort the array just in-case it is not sorted.
    + We divide the array into 4 sections with a global boolean variable.
    + We run Binary Search over each section.
    + We stop whenever the boolean variable become true.
+ [Sequential Search](https://github.com/SmallCat3699/Projects/blob/master/TCP%20(sorting%20and%20searching)/Sequential_Search.java)
    +  We divide the array into 4 sections with a global variable.
    +  We run the sequential search over each section.
    +  We stop whenver the boolean variable become true.

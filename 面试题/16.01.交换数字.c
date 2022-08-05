/**
 * Note: The returned array must be malloced, assume caller calls free().
 */
int* swapNumbers(int* numbers, int numbersSize, int* returnSize)
{
    *numbers=*numbers^*(numbers+1);
    *(numbers+1)=*numbers^*(numbers+1);
    *numbers=*numbers^*(numbers+1);
    *returnSize=2;
    return numbers;
}
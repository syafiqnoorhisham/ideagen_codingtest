# ideagen_codingtest
Calculator App

This solution uses two stacks to maintain the operands and operators, and follows the order of operations (BODMAS) by using the HasPrecedence and ApplyOp methods. It uses the tokens from the input string and checks the token if it is a operator or number and performs the corresponding operation accordingly.
It also handles the brackets and nested brackets by using push and pop from the stack. 

Time taken : 1 hrs 57 minutes

Steps:-
1. split the input string into an array of tokens 
2. stack to store the operands
3. check if the token is an open bracket, push it to the operator stack
4. if the token is an operator, pop operators from the operator stack and apply them to the operands on the operand stack
5. while the operator at the top of the operator stack has greater or equal precedence to the current operator
6. push the current operator to the operator stack
7. if the token is a closing bracket, pop operators from the operator stack and apply them to the operands on the operand stack until an open bracket is encountered
8.remove the open bracket from the operator stack
9.if the token is a number, push it to the operand stack
10. pop remaining operators from the operator stack and apply them to the operands on the operand stack
11. return the result, which should be the only remaining value on the operand stack

Space Complexity O(n), time complexity O(log n)

//
//  main.m
//  Lection 2
//
//  Created by BGatevMac on 10/26/14.
//  Copyright (c) 2014 BGatevMac. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Calculator.h"
#import "ToDo.h"

int main(int argc, const char * argv[])
{

    @autoreleasepool {
        //Task 1
        /*
        Calculator *calc = [[Calculator alloc] init];
        
        NSNumber *add = [calc addToResultValue: 27];
        
        NSLog(@"%@", add);
        NSLog(@"%@", calc.result);
        
        [calc saveResult];
        NSLog(@"%@", calc.result);
        
        NSNumber *divide = [calc divideResultBy: 3];
        NSLog(@"%@", divide);
        [calc saveResult];
      
        NSNumber *substract = [calc substractFromResultValue: 2];
        NSLog(@"%@", substract);
        [calc saveResult];
        
        NSNumber *multiply = [calc multiplyResultByValue: 5];
        NSLog(@"%@", multiply);*/
        
        //Task2
        NSString *endDate = @"26-11-2014";
        NSDateFormatter *dateFormatter = [[NSDateFormatter alloc] init];
        [dateFormatter setDateFormat:@"dd-MM-yyyy"];
        NSDate *toDoDate = [dateFormatter dateFromString:endDate];
        
        ToDo *firstToDo = [[ToDo alloc] initWithName:@"firstToDo"];
        ToDo *secondToDo = [[ToDo alloc] initWithName:@"secondToDo" andEndDate:toDoDate];
        
        [ToDo addTodo:firstToDo];
        [ToDo addTodo:secondToDo];
        [ToDo listAllTodos];
        
    }
    return 0;
}


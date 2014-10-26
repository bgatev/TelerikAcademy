//
//  Calculator.m
//  Lection 2
//
//  Created by BGatevMac on 10/26/14.
//  Copyright (c) 2014 BGatevMac. All rights reserved.
//

#import "Calculator.h"

@implementation Calculator
@synthesize result = _result;

NSNumber *tempResult;

- (id) init {
    self = [super init];
    if (self){
        self.result = @0;
    }
    
    return self;
}

-(NSNumber *) result {
    return _result;
}

- (void) saveResult {
    self.result = tempResult;
}

- (NSNumber *) addToResultValue: (float) number {
    tempResult = @([self.result floatValue] + number);

    return tempResult;
}

- (NSNumber *) divideResultBy: (float) number {
    tempResult = @([self.result floatValue] / number);
    
    return tempResult;
}

- (NSNumber *) substractFromResultValue: (float) number {
    tempResult = @([self.result floatValue] - number);
    
    return tempResult;
}

- (NSNumber *) multiplyResultByValue: (float) number {
    tempResult = @([self.result floatValue] * number);
    
    return tempResult;
}

@end

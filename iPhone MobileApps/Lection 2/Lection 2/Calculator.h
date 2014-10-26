//
//  Calculator.h
//  Lection 2
//
//  Created by BGatevMac on 10/26/14.
//  Copyright (c) 2014 BGatevMac. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Calculator : NSObject

@property (nonatomic, strong) NSNumber *result;

-(NSNumber *) result;
- (void) saveResult;

- (NSNumber *) addToResultValue: (float) number;
- (NSNumber *) divideResultBy: (float) number;
- (NSNumber *) substractFromResultValue: (float) number;
- (NSNumber *) multiplyResultByValue: (float) number;

@end

//
//  main.m
//  Lection 4
//
//  Created by BGatevMac on 10/29/14.
//  Copyright (c) 2014 BGatevMac. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Character.h"
#import "Fighter.h"
#import "Thief.h"
#import "CEO.h"
#import "CTO.h"
#import "Bachkator.h"

int main(int argc, const char * argv[])
{

    @autoreleasepool {
        Fighter *pesho = [[Fighter alloc] init];
        Thief *gosho = [[Thief alloc] init];
        CEO *shefa = [[CEO alloc] init];
        CTO *malkia = [[CTO alloc] init];
        Bachkator *golemeca = [[Bachkator alloc] init];
        [golemeca addSkill:@"Ste te tepam"];
        
        [pesho kick:gosho];
        [shefa punch:malkia];
        [golemeca use:@"Ste te tepam" onCharacter:shefa];
    }
    return 0;
}


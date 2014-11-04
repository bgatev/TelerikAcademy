//
//  Character.m
//  Lection 4
//
//  Created by BGatevMac on 10/29/14.
//  Copyright (c) 2014 BGatevMac. All rights reserved.
//

#import "Character.h"

@implementation Character

@synthesize name = _name;
@synthesize skills = _skills;
@synthesize life = _life;
@synthesize power = _power;

- (id) init {
    self = [super init];
    if (self) {
        self.skills = [[NSMutableArray alloc] init];
    }
    
    return  self;
}

- (NSString *) name {
    return _name;
}

- (void) setName: (NSString *) newName {
    _name = newName;
}

- (void) addSkill: (NSString *) skill {
    [_skills addObject:skill];
}

- (NSNumber *) life {
    return _life;
}

- (void) setLife: (NSNumber *) newLife {
    _life = newLife;
}

- (NSNumber *) power {
    return _power;
}

- (void) setPower: (NSNumber *) newPower {
    _power = newPower;
}

- (void) punch: (Character *) otherCharacter {
    int value = [self.power intValue];
    self.power = [NSNumber numberWithInt:value + 1];
    value = [otherCharacter.life intValue];
    otherCharacter.life = [NSNumber numberWithInt:value - 1];
    
    NSLog(@"Self:%@ Other:%@", self.life, otherCharacter.life);
}

- (void) kick: (Character *) otherCharacter {
    int value = [self.power intValue];
    self.power = [NSNumber numberWithInt:value + 2];
    value = [otherCharacter.life intValue];
    otherCharacter.life = [NSNumber numberWithInt:value - 2];
    
    NSLog(@"Self:%@ Other:%@", self.life, otherCharacter.life);
}

- (void) use: (NSString *) skill onCharacter:(Character *) otherCharacter {
    if (self.power < 0) return;
    
    int value = [self.power intValue];
    self.power = [NSNumber numberWithInt:value - 1];
    value = [otherCharacter.life intValue];
    otherCharacter.life = [NSNumber numberWithInt:value - 3];
    
    NSLog(@"Self:%@ Other:%@", self.life, otherCharacter.life);}

@end

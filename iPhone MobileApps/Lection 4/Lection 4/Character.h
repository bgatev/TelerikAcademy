//
//  Character.h
//  Lection 4
//
//  Created by BGatevMac on 10/29/14.
//  Copyright (c) 2014 BGatevMac. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Character : NSObject

@property (nonatomic, strong) NSString *name;
@property (nonatomic, strong) NSMutableArray *skills;
@property (nonatomic, strong) NSNumber *life;
@property (nonatomic, strong) NSNumber *power;

- (NSString *) name;
- (void) setName: (NSString *) newName;
- (void) addSkill: (NSString *) skill;
- (NSNumber *) life;
- (void) setLife: (NSNumber *) newLife;
- (NSNumber *) power;
- (void) setPower: (NSNumber *) newPower;

- (void) punch: (Character *) otherCharacter;
- (void) kick: (Character *) otherCharacter;
- (void) use: (NSString *) skill onCharacter: (Character *) otherCharacter;

@end

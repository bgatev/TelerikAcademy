//
//  CorePromotion.h
//  PrImotsiyaApp
//
//  Created by admin on 11/8/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <CoreData/CoreData.h>


@interface CorePromotion : NSManagedObject

@property (nonatomic, retain) NSString * name;
@property (nonatomic, retain) NSString * category;
@property (nonatomic, retain) NSData * picture;
@property (nonatomic, retain) NSNumber * latitudeCore;
@property (nonatomic, retain) NSNumber * longitudeCore;
@property (nonatomic, retain) NSString * moreInfo;
@property (nonatomic, retain) NSNumber * price;

//-(instancetype) initWithName:(NSString*)pName
//                      pPrice:(NSNumber*) price
//                       pInfo:(NSString*) moreInfo
//                   pcategory:(NSString*)category
//                        pPic:(NSData*)pic
//                       pLong:(NSNumber*)longitude
//                        pLat:(NSNumber*)latitude;


@end

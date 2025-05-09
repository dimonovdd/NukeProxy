using System;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace ImageCaching.Nuke
{
	// @interface DataLoader : NSObject
	[BaseType (typeof(NSObject))]
	interface DataLoader
	{
		// @property (readonly, nonatomic, strong, class) DataLoader * _Nonnull shared;
		[Static]
		[Export ("shared", ArgumentSemantic.Strong)]
		DataLoader Shared { get; }

		// @property (readonly, nonatomic, strong, class) NSURLCache * _Nonnull sharedUrlCache;
		[Static]
		[Export ("sharedUrlCache", ArgumentSemantic.Strong)]
		NSUrlCache SharedUrlCache { get; }
	}

	// @interface ImageCache : NSObject
	[BaseType (typeof(NSObject))]
	interface ImageCache
	{
		// @property (readonly, nonatomic, strong, class) ImageCache * _Nonnull shared;
		[Static]
		[Export ("shared", ArgumentSemantic.Strong)]
		ImageCache Shared { get; }

		// -(void)removeAll;
		[Export ("removeAll")]
		void RemoveAll ();
	}

	// @interface ImagePipeline : NSObject
	[BaseType (typeof(NSObject))]
	interface ImagePipeline
	{
		// @property (readonly, nonatomic, strong, class) ImagePipeline * _Nonnull shared;
		[Static]
		[Export ("shared", ArgumentSemantic.Strong)]
		ImagePipeline Shared { get; }

		// +(void)setupWithDataCache;
		[Static]
		[Export ("setupWithDataCache")]
		void SetupWithDataCache ();

		// -(BOOL)isCachedFor:(NSURL * _Nonnull)url __attribute__((warn_unused_result("")));
		[Export ("isCachedFor:")]
		bool IsCachedFor (NSUrl url);

		// -(UIImage * _Nullable)getCachedImageFor:(NSURL * _Nonnull)url __attribute__((warn_unused_result("")));
		[Export ("getCachedImageFor:")]
		[return: NullAllowed]
		UIImage GetCachedImageFor (NSUrl url);

		// -(void)removeImageFromCacheFor:(NSURL * _Nonnull)url;
		[Export ("removeImageFromCacheFor:")]
		void RemoveImageFromCacheFor (NSUrl url);

		// -(void)removeAllCaches;
		[Export ("removeAllCaches")]
		void RemoveAllCaches ();

		// -(Int64)loadImageWithUrl:(NSURL * _Nonnull)url onCompleted:(void (^ _Nonnull)(UIImage * _Nullable, NSString * _Nonnull))onCompleted;
		[Export ("loadImageWithUrl:onCompleted:")]
		long LoadImageWithUrl (NSUrl url, Action<UIImage, NSString> onCompleted);

		// -(Int64)loadImageWithUrl:(NSURL * _Nonnull)url placeholder:(UIImage * _Nullable)placeholder errorImage:(UIImage * _Nullable)errorImage into:(UIImageView * _Nonnull)into;
		[Export ("loadImageWithUrl:placeholder:errorImage:into:")]
		long LoadImageWithUrl (NSUrl url, [NullAllowed] UIImage placeholder, [NullAllowed] UIImage errorImage, UIImageView into);

		// -(Int64)loadImageWithUrl:(NSURL * _Nonnull)url placeholder:(UIImage * _Nullable)placeholder errorImage:(UIImage * _Nullable)errorImage into:(UIImageView * _Nonnull)into reloadIgnoringCachedData:(BOOL)reloadIgnoringCachedData;
		[Export ("loadImageWithUrl:placeholder:errorImage:into:reloadIgnoringCachedData:")]
		long LoadImageWithUrl (NSUrl url, [NullAllowed] UIImage placeholder, [NullAllowed] UIImage errorImage, UIImageView into, bool reloadIgnoringCachedData);

		// -(Int64)loadImageWithUrl:(NSURL * _Nonnull)url imageIdKey:(NSString * _Nonnull)imageIdKey placeholder:(UIImage * _Nullable)placeholder errorImage:(UIImage * _Nullable)errorImage into:(UIImageView * _Nonnull)into;
		[Export ("loadImageWithUrl:imageIdKey:placeholder:errorImage:into:")]
		long LoadImageWithUrl (NSUrl url, string imageIdKey, [NullAllowed] UIImage placeholder, [NullAllowed] UIImage errorImage, UIImageView into);

		// -(Int64)loadImageWithUrl:(NSURL * _Nonnull)url imageIdKey:(NSString * _Nonnull)imageIdKey placeholder:(UIImage * _Nullable)placeholder errorImage:(UIImage * _Nullable)errorImage into:(UIImageView * _Nonnull)into reloadIgnoringCachedData:(BOOL)reloadIgnoringCachedData;
		[Export ("loadImageWithUrl:imageIdKey:placeholder:errorImage:into:reloadIgnoringCachedData:")]
		long LoadImageWithUrl (NSUrl url, string imageIdKey, [NullAllowed] UIImage placeholder, [NullAllowed] UIImage errorImage, UIImageView into, bool reloadIgnoringCachedData);

		// -(Int64)loadDataWithUrl:(NSURL * _Nonnull)url onCompleted:(void (^ _Nonnull)(NSData * _Nullable, NSUrlResponse * _Nullable))onCompleted;
		[Export ("loadDataWithUrl:onCompleted:")]
		long LoadDataWithUrl (NSUrl url, Action<NSData, NSUrlResponse> onCompleted);

		// -(Int64)loadDataWithUrl:(NSURL * _Nonnull)url imageIdKey:(NSString * _Nullable)imageIdKey reloadIgnoringCachedData:(BOOL)reloadIgnoringCachedData onCompleted:(void (^ _Nonnull)(NSData * _Nullable, NSUrlResponse * _Nullable))onCompleted;
		[Export ("loadDataWithUrl:imageIdKey:reloadIgnoringCachedData:onCompleted:")]
		long LoadDataWithUrl (NSUrl url, [NullAllowed] string imageIdKey, bool reloadIgnoringCachedData, Action<NSData, NSUrlResponse> onCompleted);

		// -(Int64)cancelTasksForUrl:(NSString * _Nonnull)url;
		[Export ("cancelTasksForUrl:")]
		void CancelTasksForUrl (string url);

		// -(void)cancelTask:(Int64 * _Nonnull)taskId;
		[Export ("cancelTask:")]
		void CancelTask (long taskId);
	}

	// @interface Prefetcher : NSObject
	[BaseType (typeof(NSObject))]
	interface Prefetcher
	{
		// -(instancetype _Nonnull)initWithDestination:(enum Destination)destination __attribute__((objc_designated_initializer));
		[Export ("initWithDestination:")]
		[DesignatedInitializer]
		NativeHandle Constructor (Destination destination);

		// -(instancetype _Nonnull)initWithDestination:(enum Destination)destination maxConcurrentRequestCount:(NSInteger)maxConcurrentRequestCount __attribute__((objc_designated_initializer));
		[Export ("initWithDestination:maxConcurrentRequestCount:")]
		[DesignatedInitializer]
		NativeHandle Constructor (Destination destination, nint maxConcurrentRequestCount);

		// -(void)startPrefetchingWith:(NSArray<NSURL *> * _Nonnull)with;
		[Export ("startPrefetchingWith:")]
		void StartPrefetchingWith (NSUrl[] with);

		// -(void)stopPrefetchingWith:(NSArray<NSURL *> * _Nonnull)with;
		[Export ("stopPrefetchingWith:")]
		void StopPrefetchingWith (NSUrl[] with);

		// -(void)stopPrefetching;
		[Export ("stopPrefetching")]
		void StopPrefetching ();

		// -(void)pause;
		[Export ("pause")]
		void Pause ();

		// -(void)unPause;
		[Export ("unPause")]
		void UnPause ();
	}
}

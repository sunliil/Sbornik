using UnityEngine;
using System.Collections.Generic;
using Prime31;


public class IABUIManager : MonoBehaviourGUI
{
#if UNITY_ANDROID
	void OnGUI()
	{
		beginColumn();

		if( GUILayout.Button( "Initialize IAB" ) )
		{
			var key = "your public key from the Android developer portal here";
			GoogleIAB.init( key );
		}


		if( GUILayout.Button( "Query Inventory" ) )
		{
			// enter all the available skus from the Play Developer Console in this array so that item information can be fetched for them
			var skus = new string[] { "com.prime31.testproduct", "android.test.purchased", "com.prime31.managedproduct", "com.prime31.testsubscription" };
			GoogleIAB.queryInventory( skus );
		}


		if( GUILayout.Button( "Are subscriptions supported?" ) )
		{
			Debug.Log( "subscriptions supported: " + GoogleIAB.areSubscriptionsSupported() );
		}


		if( GUILayout.Button( "Test Purchase with Test Product" ) )
		{
			GoogleIAB.purchaseProduct( "android.test.purchased" );
		}


		if( GUILayout.Button( "Consume Test Purchase" ) )
		{
			GoogleIAB.consumeProduct( "android.test.purchased" );
		}


		if( GUILayout.Button( "Test Unavailable Item" ) )
		{
			GoogleIAB.purchaseProduct( "android.test.item_unavailable" );
		}


		endColumn( true );


		if( GUILayout.Button( "Purchase Real Product" ) )
		{
			GoogleIAB.purchaseProduct( "com.prime31.testproduct", "payload that gets stored and returned" );
		}


		if( GUILayout.Button( "Purchase Real Subscription" ) )
		{
			GoogleIAB.purchaseProduct( "com.prime31.testsubscription", "subscription payload" );
		}


		if( GUILayout.Button( "Consume Real Purchase" ) )
		{
			GoogleIAB.consumeProduct( "com.prime31.testproduct" );
		}


		if( GUILayout.Button( "Purchase Real Subscription") )
		{
			GoogleIAB.purchaseProduct( "com.prime31.testsubscription", "my subscription payload" );
		}


		if( GUILayout.Button( "Enable High Details Logs" ) )
		{
			GoogleIAB.enableLogging( true );
		}


		if( GUILayout.Button( "Consume Multiple Purchases" ) )
		{
			var skus = new string[] { "com.prime31.testproduct", "android.test.purchased" };
			GoogleIAB.consumeProducts( skus );
		}

		endColumn();
	}
#endif
}

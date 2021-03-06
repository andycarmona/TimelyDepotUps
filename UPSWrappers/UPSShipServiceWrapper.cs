﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimelyDepotMVC.UPSShipService;

namespace TimelyDepotMVC.UPSWrappers
{
    public class UPSShipServiceWrapper
    {

        public string UserName { get; set; }
        public string Pasword { get; set; }
        public string AccessLicenseNumber { get; set; }
        public string ShipperNumber { get; set; }
        public string ShipperName { get; set; }
        public string ShipperAddressLine { get; set; }
        public string ShipperCity { get; set; }
        public string ShipperPostalCode { get; set; }
        public string ShipperStateProvinceCode { get; set; }
        public string ShipperCountryCode { get; set; }
        public string ShipToPostalCode { get; set; }
        public string ShipToCountryCode { get; set; }
        public string ShipToName { get; set; }
        public string ShipToAddressLine { get; set; }
        public string ShipToCity { get; set; }
        public string ShipToStateProvinceCode { get; set; }

        public string ShipFromAddressLine { get; set; }
        public string ShipFromCity { get; set; }
        public string ShipFromPostalCode { get; set; }
        public string ShipFromStateProvinceCode { get; set; }
        public string ShipFromCountryCode { get; set; }
        public string ShipFromName { get; set; }
        public string BillShipperAccountNumber { get; set; }
        public string PackagingTypeCode { get; set; }
        public string ShipmentChargeType { get; set; }
        public string FreightBillingOption { get; set; }

        public UPSShipServiceWrapper(string userName, string password, string accessLicenseNumber,
             string shipperNumber, string shipperName, string shipperAddressLine, string shipperCity,
            string shipperPostalCode, string shipperStateProvinceCode, string shipperCountryCode,
            string shipToPostalCode, string shipToCountryCode, string shipToName, string shipToAddressLine,
            string shipToCity, string shipToStateProvinceCode, string shipFromAddressLine,
            string shipFromCity, string shipFromPostalCode, string shipFromStateProvinceCode,
            string shipFromCountryCode, string shipFromName, string billShipperAccountNumber,
             string packagingTypeCode, string shipmentChargeType)
        {
            UserName = userName;
            Pasword = password;
            AccessLicenseNumber = accessLicenseNumber;
            ShipperNumber = shipperNumber;
            ShipperName = shipperName;
            ShipperAddressLine = shipperAddressLine;
            ShipperCity = shipperCity;
            ShipperPostalCode = shipperPostalCode;
            ShipperStateProvinceCode = shipperStateProvinceCode;
            ShipperCountryCode = shipperCountryCode;
            ShipToPostalCode = shipToPostalCode;
            ShipToCountryCode = shipToCountryCode;
            ShipToName = shipToName;
            ShipToAddressLine = shipToAddressLine;
            ShipToCity = shipToCity;
            ShipToStateProvinceCode = shipToStateProvinceCode;
            ShipFromAddressLine = shipFromAddressLine;
            ShipFromCity = shipFromCity;
            ShipFromPostalCode = shipFromPostalCode;
            ShipFromStateProvinceCode = shipFromStateProvinceCode;
            ShipFromCountryCode = shipFromCountryCode;
            ShipFromName = shipFromName;
            BillShipperAccountNumber = billShipperAccountNumber;
            PackagingTypeCode = packagingTypeCode;
            ShipmentChargeType = shipmentChargeType;
            //FreightBillingOption = freightBillingOption;
        }

        #region Private

        private void AddUpsSecurity(ShipService upsShipService)
        {
            var upss = new UPSSecurity();
            AddUpsServiceAccessToken(upss);
            AddUserNameToken(upss);
            upsShipService.UPSSecurityValue = upss;
        }

        private void AddUpsServiceAccessToken(UPSSecurity upss)
        {
            var upssSvcAccessToken = new UPSSecurityServiceAccessToken();
            upssSvcAccessToken.AccessLicenseNumber = AccessLicenseNumber;
            upss.ServiceAccessToken = upssSvcAccessToken;
        }

        private void AddUserNameToken(UPSSecurity upss)
        {
            var upssUsrNameToken = new UPSSecurityUsernameToken();
            upssUsrNameToken.Username = UserName;
            upssUsrNameToken.Password = Pasword;
            upss.UsernameToken = upssUsrNameToken;
        }

        private void AddShipper(ShipmentType shipment)
        {
            var shipper = new ShipperType();
            shipper.ShipperNumber = ShipperNumber;
            shipper.Name = ShipperName;
            AddShipperAddress(shipper);
            shipment.Shipper = shipper;
        }

        private void AddShipperAddress(ShipperType shipper)
        {
            var shipperAddress = new ShipAddressType();
            shipperAddress.AddressLine = new String[] { ShipperAddressLine };
            shipperAddress.City = ShipperCity;
            shipperAddress.PostalCode = ShipperPostalCode;
            shipperAddress.StateProvinceCode = ShipperStateProvinceCode;
            shipperAddress.CountryCode = ShipperCountryCode;
            shipper.Address = shipperAddress;
        }

        private void AddShipToAddress(ShipmentType shipment)
        {
            var shipTo = new ShipToType();
            var shipToAddress = new ShipToAddressType();
            shipToAddress.AddressLine = new String[] { ShipToAddressLine };
            shipToAddress.City = ShipToCity;//txtPShipToCity.Text;
            shipToAddress.PostalCode = ShipToPostalCode;
            shipToAddress.StateProvinceCode = ShipToStateProvinceCode;
            shipToAddress.CountryCode = ShipToCountryCode;
            shipTo.Address = shipToAddress;
            shipTo.Name = ShipToName;
            shipment.ShipTo = shipTo;
        }

        private void AddShipFromAddress(ShipmentType shipment)
        {
            var shipFrom = new ShipFromType();
            var shipFromAddress = new ShipAddressType();
            shipFromAddress.AddressLine = new String[] { ShipFromAddressLine };
            shipFromAddress.City = ShipFromCity;
            shipFromAddress.PostalCode = ShipFromPostalCode;
            shipFromAddress.StateProvinceCode = ShipFromStateProvinceCode;
            shipFromAddress.CountryCode = ShipFromCountryCode;
            shipFrom.Address = shipFromAddress;
            shipFrom.Name = ShipFromName;
            shipment.ShipFrom = shipFrom;
        }

        private void AddBillShipperAccount(ShipmentType shipment)
        {
            var paymentInfo = new PaymentInfoType();
            var shpmentCharge = new ShipmentChargeType();
            var billShipper = new BillShipperType();
            billShipper.AccountNumber = BillShipperAccountNumber;
            shpmentCharge.BillShipper = billShipper;
            shpmentCharge.Type = ShipmentChargeType;
            ShipmentChargeType[] shpmentChargeArray = { shpmentCharge };
            paymentInfo.ShipmentCharge = shpmentChargeArray;
            shipment.PaymentInformation = paymentInfo;
        }

        /*private void AddPaymentInformation(ShipmentType shipment)
        {
            var paymentInfo = new PaymentInfoType();
            var paymentInfoType = new PaymentType();
            paymentInfoType.Code
            shipper.ShipperNumber = ShipperNumber;
            shipper.Name = ShipperName;
            AddShipperAddress(shipper);
            shipment.Shipper = shipper;
        }*/

        private void AddPackage(int boxWeight, int declaredVal, int boxHeight, int boxWidth, int boxLength, string packagingTypeCode, string currencyCode, PackageType[] pkgArray, int pos)
        {
            var package = new PackageType();
            var packageWeight = new PackageWeightType();
            packageWeight.Weight = boxWeight.ToString();
            var uom = new ShipUnitOfMeasurementType();
            uom.Code = "LBS";
            uom.Description = "pounds";
            packageWeight.UnitOfMeasurement = uom;
            package.PackageWeight = packageWeight;

            var packageDimensions = new DimensionsType();
            packageDimensions.Height = boxHeight.ToString();
            packageDimensions.Length = boxLength.ToString();
            packageDimensions.Width = boxWidth.ToString();
            var packDimType = new ShipUnitOfMeasurementType();
            packDimType.Code = "IN";
            packDimType.Description = "Inches";
            packageDimensions.UnitOfMeasurement = packDimType;
            package.Dimensions = packageDimensions;

            var packageServiceOptions = new PackageServiceOptionsType();
            var declaredValue = new PackageDeclaredValueType();
            declaredValue.CurrencyCode = currencyCode;
            declaredValue.MonetaryValue = declaredVal.ToString();
            packageServiceOptions.DeclaredValue = declaredValue;
            package.PackageServiceOptions = packageServiceOptions;

            var packType = new PackagingType();
            packType.Code = packagingTypeCode;
            package.Packaging = packType;
            pkgArray[pos] = package;
        }

        #endregion

        public ShipmentResponse CallUPSShipmentRequest(string serviceCode, int ShipmentID)
        {
            //var dbShipment = ShipmentModule.GetShipmentByID(ShipmentID);
            var shipmentDetails = ShipmentModule.GetShipmentShipmentDetails(ShipmentID);

            var shpSvc = new ShipService();
            var shipmentRequest = new ShipmentRequest();
            AddUpsSecurity(shpSvc);
            var request = new RequestType();
            String[] requestOption = { "1" }; //{ "nonvalidate" };
            request.RequestOption = requestOption;
            shipmentRequest.Request = request;
            var shipment = new ShipmentType();
            shipment.Description = "Ship webservice example";
            AddShipper(shipment);
            AddShipFromAddress(shipment);
            AddShipToAddress(shipment);
            AddBillShipperAccount(shipment);
            //AddPaymentInformation(shipment);

            var service = new ServiceType();
            service.Code = serviceCode;
            shipment.Service = service;

            PackageType[] pkgArray;
            pkgArray = new PackageType[shipmentDetails.Count];
            var i = 0;
            foreach (var box in shipmentDetails)
            {
                AddPackage(box.UnitWeight.Value, Convert.ToInt32(box.UnitPrice), box.DimensionH.Value, box.DimensionD.Value, box.DimensionL.Value, PackagingTypeCode, "USD", pkgArray, i);
                i = i + 1;
            }
            shipment.Package = pkgArray;

            var labelSpec = new LabelSpecificationType();
            var labelStockSize = new LabelStockSizeType();
            labelStockSize.Height = "3";
            labelStockSize.Width = "2";
            labelSpec.LabelStockSize = labelStockSize;
            var labelImageFormat = new LabelImageFormatType();
            labelImageFormat.Code = "GIF";//"SPL";
            labelSpec.LabelImageFormat = labelImageFormat;
            shipmentRequest.LabelSpecification = labelSpec;
            shipmentRequest.Shipment = shipment;

            var shipmentResponse = shpSvc.ProcessShipment(shipmentRequest);
            return shipmentResponse;
        }
    }
}
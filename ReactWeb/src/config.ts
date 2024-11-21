const config = {
   // baseApiUrl: "https://localhost:4000",  //base url of the API
    baseApiUrl: "",  //*keep it blank because it is not running in the same domain 
                     //*so we can just use relative urlas the api so keep it blank
  };
  
  const currencyFormatter = Intl.NumberFormat("en-US", {
    style: "currency",
    currency: "USD",
    maximumFractionDigits: 0,
  });
  
  export default config;
  
  export { currencyFormatter };
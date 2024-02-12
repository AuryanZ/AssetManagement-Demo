const Header = () => {
    return (
      <header className="bg-[#09A94E] px-4 flex justify-end items-center">
          {/* logo here */}
          <div className="flex items-center">
            <h1 className="text-white text-2xl font-bold">Asset Management System</h1>
            <img src="/logo.png" alt="logo" className="w-20 mx-4"/>
            </div>
      </header>
    );
  };
  
  export default Header;
import DisplayUsers from './Components/DisplayUsers';
import DeleteUser from './Components/DeleteUsers';
import InsertUser from './Components/InsertUser';
import UpdateData from './Components/UpdateUser';
import RegisterUser from './Components/RegisterUser';
import LoginUser from './Components/LoginUser';

function App() {
  return (
   <>
   <RegisterUser/>
   <LoginUser/>
   <DisplayUsers/>
   <InsertUser/>
   <DeleteUser/>
   <UpdateData/>
   </>
  );
}

export default App;

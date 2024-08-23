namespace BankNUnitTest
{
    public class Tests
    {
        private BankAccount _account;
        private BankAccount _toAccount;

        [SetUp]
        public void Setup()
        {
            _account = new BankAccount();
            _toAccount = new BankAccount();
        }

        [Test]
        public void DepositValidAmountIncreasesBalance()
        {
            //arrange
            double depositAmount = 1000;

            //act
            _account.Deposit(depositAmount);

            //assert
            Assert.AreEqual(depositAmount, _account.GetBalance());
        }

        [Test]
        public void DepositInvalidAmountThrowsException()
        {
            double invalidAmount = -1000;

            Assert.Throws<ArgumentException>(() => _account.Deposit(invalidAmount));
        }

        [Test]
        public void WithdrawValidAmountDecreasesBalance()
        {
            //arrange
            double depositAmount = 1000;
            double withdrawAmount = 500;
            _account.Deposit(depositAmount);

            //act
            _account.Withdraw(withdrawAmount);

            //assert
            Assert.AreEqual(depositAmount - withdrawAmount, _account.GetBalance());
        }

        [Test]
        public void WithdrawInvalidAmountThrowsException()
        {
            //arrange
            double invalidAmount = -500;

            Assert.Throws<ArgumentException>(() => _account.Withdraw(invalidAmount));
        }

        [Test]
        public void WithdrawAmountGreaterThanBalanceThrowsException()
        {
            double depositAmount = 500;
            double withdrawAmount = 1000;
            _account.Deposit(depositAmount);

            Assert.Throws<InvalidOperationException>(() => _account.Withdraw(withdrawAmount));
        }

        [Test]
        public void TransferValidAmountUpdateBothAccounts()
        {
            //arrange
            double depositAmount = 1000;
            double transferAmount = 500;
            _account.Deposit(depositAmount);

            //act
            _account.Transfer(_toAccount, transferAmount);

            //assert
            Assert.AreEqual(depositAmount - transferAmount, _account.GetBalance());
            Assert.AreEqual(transferAmount, _toAccount.GetBalance());
        }

        [Test]
        public void TransferInvalidAmountThrowsException()
        {
            //arrange
            double transferAmount = 500;

            Assert.Throws<ArgumentNullException>(() => _account.Transfer(null, transferAmount));
        }
    }
}